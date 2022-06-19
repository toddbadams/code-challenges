using System;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace Simulator.Repositories
{
    public class SecretsRepository : ISecretsRepository
    {
        private readonly SecretClient _client;

        /// <summary>
        /// Create a new secret client using the default credential from Azure.Identity using environment variables previously set,
        /// including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
        /// </summary>
        public SecretsRepository(string keyVaultUrl)
        {
            _client = new SecretClient(vaultUri: new Uri(keyVaultUrl), credential: new DefaultAzureCredential());
        }

        public string BlobStorageConnectionString => _client.GetSecret("blob-storage-connection-string").Value.ToString();
    }
}