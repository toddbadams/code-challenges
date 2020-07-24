using System;
using System.Linq;
using System.Threading.Tasks;
using DataFactory.Application.Repositories;
using Microsoft.Azure.Management.DataFactory;

namespace DataFactory.Services
{
    public class DataFactoryService : IDataFactoryService
    {
        private readonly IDataFactoryManagementClient _client;
        private readonly IParameterFactory _parameters;

        private readonly string _resourceGroup;
        private readonly string _dataFactory;
        private readonly string _storage;
        private readonly string _dataset;
        private readonly string _pipeline;

        private const string PendingCreationProvisioningState = "PendingCreation";
        private const string ErrorPipelineStatus = "Error";
        private const string InProgressPipelineStatus = "InProgress";
        private const string QueuedPipelineStatus = "Queued";

        public DataFactoryService(IDataFactoryManagementClient client, IConfigurationRepository configuration, IParameterFactory parameters)
        {
            _client = client;
            _resourceGroup = configuration.ResourceGroup;
            _dataFactory = configuration.DataFactoryName;
            _storage = configuration.StorageAccountName;
            _dataset = configuration.DatasetName;
            _pipeline = configuration.PipelineName;
            _parameters = parameters;
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