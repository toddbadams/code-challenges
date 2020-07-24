using System;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace DataFactory.Repositories
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

        public string TenantId => _client.GetSecret("tenant-id").Value.ToString();
        public string ApplicationId => _client.GetSecret("application-id").Value.ToString();
        public string AuthenticationKey => _client.GetSecret("authentication-key").Value.ToString();
        public string SubscriptionId => _client.GetSecret("subscription-id").Value.ToString();
        public string StorageKey => _client.GetSecret("blob-storage-key").Value.ToString();
    }
}
