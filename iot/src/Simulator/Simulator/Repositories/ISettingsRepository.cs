using System.Threading.Tasks;
using Simulator.Configurations;

namespace Simulator.Repositories
{
    public interface ISettingsRepository
    {
        Task<Settings> Load();
    }
}