using System.Threading.Tasks;
using RefrigeratedTruck.Domain.Entities;

namespace RefrigeratedTruck.Application.Repositories
{
    public interface ICustomersRepository
    {
        Task<Customer> Get(string id);
    }
}