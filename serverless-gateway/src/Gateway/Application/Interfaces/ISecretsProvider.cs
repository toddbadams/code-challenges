using System.Threading.Tasks;

namespace Gateway.Application.Interfaces
{
    public interface ISecretsProvider
    {
        Task<string> Get(string key);
    }
}