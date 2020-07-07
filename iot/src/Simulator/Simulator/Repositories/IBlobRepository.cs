using System.Threading.Tasks;

namespace Simulator.Repositories
{
    public interface IBlobRepository
    {
        Task<T> LoadBlob<T>(string containerName, string fileName);
    }
}