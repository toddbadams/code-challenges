using System;
using System.Linq;
using System.Threading.Tasks;
using DataFactory.Application.Repositories;
using DataFactory.FunctionApp;
using DataFactory.Repositories;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;

namespace DataFactory.Services
{
    public class DataFactoryRepository : IDataFactoryRepository
    {
        private readonly IDataFactoryManagementClient _client;
        private readonly ISecretsRepository _secrets;
        private readonly IParameterFactory _parameters;
        private const string ResourceUrl = "https://management.azure.com/";

        private readonly string _resourceGroup;
        private readonly string _storage;
        private readonly string _dataset;
        private readonly string _pipeline;

        private const string PendingCreationProvisioningState = "PendingCreation";
        private const string ErrorPipelineStatus = "Error";
        private const string InProgressPipelineStatus = "InProgress";
        private const string QueuedPipelineStatus = "Queued";

        public DataFactoryRepository(IDataFactoryManagementClient client,
            IConfigurationRepository configuration,
            ISecretsRepository secrets,
            IParameterFactory parameters)
        {
            _client = client;
            _secrets = secrets;
            _resourceGroup = configuration.ResourceGroup;
            _storage = configuration.StorageAccountName;
            _dataset = configuration.DatasetName;
            _pipeline = configuration.PipelineName;
            _parameters = parameters;
        }

        // todo - move to active directory repo
        public async Task<string> CreateAccessToken() =>
            (await _parameters.AuthenticationContext()
                .AcquireTokenAsync(ResourceUrl, _parameters.ClientCredential())).AccessToken;

        public async Task<Factory> CreateDataFactory(DataFactoryAccess dfAccess) =>
            await _parameters.CreateDataFactoryManagementClient(dfAccess.Token)
                .Factories.CreateOrUpdateAsync(_resourceGroup, dfAccess.Name, _parameters.DataFactory());

        public async Task<bool> IsPendingCreation(DataFactoryAccess dfAccess) =>
            (await _parameters.CreateDataFactoryManagementClient(dfAccess.Token)
                .Factories.GetAsync(_resourceGroup, dfAccess.Name))
            .ProvisioningState == PendingCreationProvisioningState;

        public async Task<LinkedServiceResource> CreateLinkedService(DataFactoryAccess dfAccess) =>
           await _parameters.CreateDataFactoryManagementClient(dfAccess.Token)
                .LinkedServices.CreateOrUpdateAsync(_resourceGroup, dfAccess.Name, _storage,
                    _parameters.LinkedServiceResource());

        public void CreateDataSet(DataFactoryAccess dfAccess) =>
            _client.Datasets.CreateOrUpdate(_resourceGroup, dfAccess.Name, _dataset, _parameters.CreateDatasetResource());

        public void CreatePipeline(DataFactoryAccess dfAccess) =>
            _client.Pipelines.CreateOrUpdate(_resourceGroup, dfAccess.Name, _pipeline, _parameters.CreatePipelineResource());

        public async Task<string> CreatePipelineRunId(DataFactoryAccess dfAccess) =>
            (await _client.Pipelines.CreateRunWithHttpMessagesAsync(
                _resourceGroup, dfAccess.Name, _pipeline, parameters: _parameters.CreatePipelineParameters()
            )).Body.RunId;

        public bool IsPipelineRunInProgressOrQueued(DataFactoryAccess dfAccess, string runId)
        {
            var pipelineRun = _client.PipelineRuns.Get(_resourceGroup, dfAccess.Name, runId);
            if (pipelineRun.Status == ErrorPipelineStatus) throw new ApplicationException(ErrorPipelineStatus);
            return pipelineRun.Status == InProgressPipelineStatus || pipelineRun.Status == QueuedPipelineStatus;
        }

        public object GetCopyActivityOutput(DataFactoryAccess dfAccess, string runId) =>
            _client.ActivityRuns.QueryByPipelineRun(_resourceGroup, dfAccess.Name, runId, _parameters.FilterParameters()).Value.First().Output;

    }
}