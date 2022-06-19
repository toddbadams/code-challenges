using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;

namespace Simulator.Repositories
{
    public class BlobRepository<T> : IBlobRepository
    {
        private readonly CloudBlobClient _serviceClient;

        public BlobRepository(ISecretsRepository secrets)
        {
            var storageAccount = CloudStorageAccount.Parse(secrets.BlobStorageConnectionString);

            _serviceClient = storageAccount.CreateCloudBlobClient();
        }
        public async Task<T> LoadBlob<T>(string containerName, string fileName)
        {
            var json = await _serviceClient
                .GetContainerReference($"{containerName}")
                .GetBlockBlobReference($"{fileName}")
                .DownloadTextAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}