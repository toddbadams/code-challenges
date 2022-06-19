//using Azure.Messaging.ServiceBus;
//using Microsoft.Azure.WebJobs;
//using System;
//using System.Threading.Tasks;

//namespace Tba.CqrsEs.Presentation
//{
//    public class EventStore
//    {
//        [FunctionName("EventStore")]
//        public async Task Run([ServiceBusTrigger("events", "wines-subscriber", Connection = "TopicListen")]
//            ServiceBusMessage message,
//            //MessageReceiver messageReceiver,
//            string lockToken,

//            [CosmosDB("wines", "events", ConnectionStringSetting = "CosmosDBConnection")]
//            IAsyncCollector<ServiceBusMessage> dbAsyncCollector)
//        {
//            try
//            {
//                await dbAsyncCollector.AddAsync(message);
//            }
//            catch (Exception)
//            {
//                // await messageReceiver.DeadLetterAsync(lockToken);
//            }
//        }
//    }
//}
