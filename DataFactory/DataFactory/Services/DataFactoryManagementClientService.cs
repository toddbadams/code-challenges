using System.Threading.Tasks;
using DataFactory.Repositories;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;

namespace DataFactory
{
    public class DataFactoryManagementClientService : IDataFactoryManagementClientService
    {
        private readonly ISecretsRepository _secrets;
        private const string AuthorityUrl = "https://login.windows.net/";
        private const string ResourceUrl = "https://management.azure.com/";

        public DataFactoryManagementClientService(ISecretsRepository secrets)
        {
            _secrets = secrets;
        }

        public async Task<IDataFactoryManagementClient> CreateClient()
        {
            var context = new AuthenticationContext(AuthorityUrl + _secrets.TenantId);
            var clientCredential = new ClientCredential(_secrets.ApplicationId, _secrets.AuthenticationKey);
            var result = await context.AcquireTokenAsync(ResourceUrl, clientCredential);
            return new DataFactoryManagementClient(new TokenCredentials(result.AccessToken))
            {
                SubscriptionId = _secrets.SubscriptionId
            };
        }
    }
}