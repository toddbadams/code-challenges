using System;
using System.Linq;
using System.Threading.Tasks;
using DataFactory.Application.Repositories;
using DataFactory.Repositories;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;

namespace DataFactory.Services
{
    public class DataFactoryRepository : IDataFactoryRepository
    {
        private readonly IDataFactoryManagementClient _client;
        private readonly ISecretsRepository _secrets;
        private readonly IParameterFactory _parameters;

        private readonly string _resourceGroup;
        private readonly string _dataFactory;
        private readonly string _storage;
        private readonly string _dataset;
        private readonly string _pipeline;

        private const string AuthorityUrl = "https://login.windows.net/";
        private const string ResourceUrl = "https://management.azure.com/";

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
            _dataFactory = configuration.DataFactoryName;
            _storage = configuration.StorageAccountName;
            _dataset = configuration.DatasetName;
            _pipeline = configuration.PipelineName;
            _parameters = parameters;
        }

        public async Task<IDataFactoryManagementClient> CreateClient()
        {
            var context = new AuthenticationContext(AuthorityUrl + _secrets.TenantId);
            var clientCredential = new ClientCredential(_secrets.ApplicationId, _secrets.AuthenticationKey);
            var result = await context.AcquireTokenAsync(ResourceUrl, clientCredential);
            return new DataFactoryManagementClient(new TokenCredentials(result.AccessToken))
            {
                SubscriptionId = _secrets.SubscriptionId
            };
        }

        public void CreateDataFactory() =>
            _client.Factories.CreateOrUpdate(_resourceGroup, _dataFactory, _parameters.DataFactory());

        public bool IsPendingCreation() =>
            _client.Factories.Get(_resourceGroup, _dataFactory).ProvisioningState == PendingCreationProvisioningState;

        public void CreateLinkedService() =>
            _client.LinkedServices.CreateOrUpdate(_resourceGroup, _dataFactory, _storage,
                _parameters.CreatedLinkedServiceResource());

        public void CreateDataSet() =>
            _client.Datasets.CreateOrUpdate(_resourceGroup, _dataFactory, _dataset, _parameters.CreateDatasetResource());

        public void CreatePipeline() =>
            _client.Pipelines.CreateOrUpdate(_resourceGroup, _dataFactory, _pipeline, _parameters.CreatePipelineResource());

        public async Task<string> CreatePipelineRunId() =>
            (await _client.Pipelines.CreateRunWithHttpMessagesAsync(
                _resourceGroup, _dataFactory, _pipeline, parameters: _parameters.CreatePipelineParameters()
            )).Body.RunId;

        public bool IsPipelineRunInProgressOrQueued(string runId)
        {
            var pipelineRun = _client.PipelineRuns.Get(_resourceGroup, _dataFactory, runId);
            if (pipelineRun.Status == ErrorPipelineStatus) throw new ApplicationException(ErrorPipelineStatus);
            return pipelineRun.Status == InProgressPipelineStatus || pipelineRun.Status == QueuedPipelineStatus;
        }

        public object GetCopyActivityOutput(string runId) =>
            _client.ActivityRuns.QueryByPipelineRun(_resourceGroup, _dataFactory, runId, _parameters.FilterParameters()).Value.First().Output;
    }
}