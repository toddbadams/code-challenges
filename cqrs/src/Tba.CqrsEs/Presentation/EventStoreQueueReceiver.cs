using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs;
using System;
using System.Threading.Tasks;

namespace Tba.CqrsEs.Presentation
{
    public class EventStoreQueueReceiver
    {
        private const string ServiceBusQueueName = "winetastings";
        private const string ServiceBusConnection = "TopicSent";
        private const string CosmosContainerName = "winetastings";
        private const string CosmosCollectionName = "events";
        private const string CosmosConnection = "CosmosDBConnection";

        [FunctionName("EventStore")]
        public async Task Run([ServiceBusTrigger(ServiceBusQueueName, Connection = ServiceBusConnection)]
            ServiceBusMessage message,
            //MessageReceiver messageReceiver,
            string lockToken,

            [CosmosDB(CosmosContainerName, CosmosCollectionName, ConnectionStringSetting = CosmosConnection)]
            IAsyncCollector<ServiceBusMessage> dbAsyncCollector)
        {
            try
            {
                await dbAsyncCollector.AddAsync(message);
            }
            catch (Exception)
            {
                // await messageReceiver.DeadLetterAsync(lockToken);
            }
        }
    }
}
