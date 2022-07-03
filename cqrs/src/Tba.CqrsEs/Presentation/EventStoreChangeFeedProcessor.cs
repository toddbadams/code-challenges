using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tba.CqrsEs.Presentation
{
    public static class EventStoreChangeFeedProcessor
    {
        private const string CosmosContainerName = "winetastings";
        private const string CosmosCollectionName = "events";
        private const string CosmosLeasesCollectionName = "leases";
        private const string CosmosConnection = "CosmosDBConnection";

        [Disable("MY_TIMER_DISABLED")]
        [FunctionName("EventStoreChangeFeedProcessor")]
        public static void Run(
            [CosmosDBTrigger(databaseName: CosmosContainerName,
            collectionName: CosmosCollectionName,
            ConnectionStringSetting = CosmosConnection,
            LeaseConnectionStringSetting = CosmosConnection,
            LeaseCollectionName = CosmosLeasesCollectionName,
            CreateLeaseCollectionIfNotExists = true)]IReadOnlyList<Document> documents)
        {
            foreach (var doc in documents)
            {
                string json = JsonConvert.SerializeObject(doc);

            }
        }
    }
}
