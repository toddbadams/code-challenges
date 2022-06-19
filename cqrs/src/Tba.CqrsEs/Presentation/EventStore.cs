using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs;
using System;
using System.Threading.Tasks;

namespace Tba.CqrsEs.Presentation
{
    public class EventStore
    {
        private const string ServiceBusQueueName = "winetastings";
        private const string ServiceBusConnection = "TopicSent";

        [FunctionName("EventStore")]
        public async Task Run([ServiceBusTrigger(ServiceBusQueueName, Connection = ServiceBusConnection)]
            ServiceBusMessage message,
            //MessageReceiver messageReceiver,
            string lockToken,

            [CosmosDB("winetastings", "events", ConnectionStringSetting = "CosmosDBConnection")]
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
