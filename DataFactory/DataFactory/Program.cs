using DataFactory.Repositories;
using DataFactory.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DataFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ISecretsRepository, SecretsRepository>()
                .BuildServiceProvider();

            var secrets = serviceProvider.GetService<ISecretsRepository>();
            IDataFactoryManagementClientService clientService = new DataFactoryManagementClientService(secrets);

            var client = clientService.CreateClient().Result;
            var dfService = new DataFactoryRepository(client, null, null);
            dfService.CreateDataFactory();
            while (dfService.IsPendingCreation())
            {
                System.Threading.Thread.Sleep(1000);
            }
            dfService.CreateLinkedService();
            dfService.CreateDataSet();
            dfService.CreatePipeline();
            var runId = dfService.CreatePipelineRunId().Result;
            while (dfService.IsPipelineRunInProgressOrQueued(runId))
            {
                System.Threading.Thread.Sleep(15000);
            }
            var o = dfService.GetCopyActivityOutput(runId);
        }

    }
}
