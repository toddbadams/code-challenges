using System;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Azure.WebJobs;

namespace Tba.CqrsEs.Presentation
{
    public class EventStore
    {
        [FunctionName("Function1")]
        public  async Task Run([ServiceBusTrigger("events", "wines-subscriber", Connection = "TopicListen")]
            Message message, 
            MessageReceiver messageReceiver,
            string lockToken,

            [CosmosDB("wines", "events", ConnectionStringSetting = "CosmosDBConnection")]
            IAsyncCollector<Message> dbAsyncCollector)
        {
            try
            {
                await dbAsyncCollector.AddAsync(message);
            }
            catch (Exception)
            {
                await messageReceiver.DeadLetterAsync(lockToken);
            }
        }
    }
}
