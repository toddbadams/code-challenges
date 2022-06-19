using System.Threading.Tasks;
using Microsoft.Azure.Management.DataFactory;

namespace DataFactory
{
    public interface IDataFactoryManagementClientService
    {
        Task<IDataFactoryManagementClient> CreateClient();
    }
}
