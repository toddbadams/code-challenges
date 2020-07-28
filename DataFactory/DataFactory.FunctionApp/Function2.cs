using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace DataFactory.FunctionApp
{
    public class DataFactoryFunction
    {
        private readonly IDataFactoryRepository _dataFactory;

        public DataFactoryFunction(IDataFactoryRepository dataFactoryRepository)
        {
            _dataFactory = dataFactoryRepository;
        }

        [FunctionName("DataFactoryOrchestrator")]
        public async Task<string> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var accessToken = await _dataFactory.CreateAccessToken();
            var inputData = new DataFactoryAccess(accessToken, "fin-datafactory-westeurope");

            await context.CallActivityAsync<Factory>("CreateDataFactory", inputData);

            try
            {
                // check if the data factory has been provisioned every minute for up to 10 minutes
                await context.CallActivityWithRetryAsync<bool>("IsPendingCreation",
                    new RetryOptions(TimeSpan.FromMinutes(1), 10), inputData);
            }
            catch
            {
                return "Failed to provision data factory";
            }

            await CreateLinkedService(inputData);

            return string.Empty;
        }

        [FunctionName("CreateDataFactory")]
        public Task<Factory> CreateDataFactory([ActivityTrigger] DataFactoryAccess dfAccess) =>
            _dataFactory.CreateDataFactory(dfAccess);

        [FunctionName("IsPendingCreation")]
        public async Task<bool> IsPendingCreation([ActivityTrigger] DataFactoryAccess dfAccess)
        {
            var result = await _dataFactory.IsPendingCreation(dfAccess);
            if (!result)
                throw new ApplicationException();
            return true;
        }

        [FunctionName("CreateLinkedService")]
        public Task<LinkedServiceResource> CreateLinkedService([ActivityTrigger] DataFactoryAccess dfAccess) =>
            _dataFactory.CreateLinkedService(dfAccess);

        [FunctionName("DataFactoryStarter")]
        public async Task<HttpResponseMessage> DataFactoryStarter(
        [HttpTrigger(AuthorizationLevel.Function, methods: "post", Route = "orchestrators/{functionName}/{instanceId}")] HttpRequestMessage req,
            [DurableClient] IDurableOrchestrationClient starter,
            string functionName,
            string instanceId,
            ILogger log)
        {
            instanceId = await starter.StartNewAsync(functionName, instanceId);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);
        }


        //var serviceProvider = new ServiceCollection()
        //    .AddSingleton<ISecretsRepository, SecretsRepository>()
        //    .BuildServiceProvider();

        //var secrets = serviceProvider.GetService<ISecretsRepository>();
        //IDataFactoryManagementClientService clientService = new DataFactoryManagementClientService(secrets);

        //var client = clientService.CreateClient().Result;
        //var dfService = new DataFactoryRepository(client, null, null);
        //dfService.CreateDataFactory();
        //while (dfService.IsPendingCreation())
        //{
        //    System.Threading.Thread.Sleep(1000);
        //}
        //dfService.CreateLinkedService();
        //dfService.CreateDataSet();
        //dfService.CreatePipeline();
        //var runId = dfService.CreatePipelineRunId().Result;
        //    while (dfService.IsPipelineRunInProgressOrQueued(runId))
        //{
        //    System.Threading.Thread.Sleep(15000);
        //}
        //var o = dfService.GetCopyActivityOutput(runId);
    }
}