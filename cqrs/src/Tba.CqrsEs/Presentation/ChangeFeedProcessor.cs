//using Microsoft.Azure.Documents;
//using Microsoft.Azure.WebJobs;
//using Newtonsoft.Json;
//using System.Collections.Generic;

//namespace Tba.CqrsEs.Presentation
//{
//    /// <summary>
//    /// Processes events using Cosmos DB Change Feed.
//    /// </summary>
//    public static class ChangeFeedProcessor
//    {
//        [FunctionName("ChangeFeedProcessor")]
//        public static void Run(
//            //change database name below if different than specified in the lab
//            [CosmosDBTrigger(databaseName: "wines",
//            //change the collection name below if different than specified in the lab
//            collectionName: "events",
//            ConnectionStringSetting = "DBconnection",
//            LeaseConnectionStringSetting = "DBconnection",
//            LeaseCollectionName = "leases",
//            CreateLeaseCollectionIfNotExists = true)]IReadOnlyList<Document> documents)
//        {
//            foreach (var doc in documents)
//            {
//                string json = JsonConvert.SerializeObject(doc);

//            }
//        }
//    }
//}
