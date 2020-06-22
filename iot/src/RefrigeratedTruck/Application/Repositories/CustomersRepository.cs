using System.Collections.Generic;
using System.Threading.Tasks;
using RefrigeratedTruck.Domain.Entities;

namespace RefrigeratedTruck.Application.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private static readonly IDictionary<string, Customer> Customers = new Dictionary<string, Customer>
        {
            {"1", new Customer("1", 47.645892, -122.336954)},
            {"2", new Customer("2", 47.688741, -122.402965)},
            {"3", new Customer("3", 47.551093, -122.065996)},
            {"4", new Customer("4", 47.555698, -122.065996)},
            {"5", new Customer("5", 47.663747, -122.120879)},
            {"6", new Customer("6", 47.857295, -122.316355)},
            {"7", new Customer("7", 47.530250, -122.393055)},
            {"8", new Customer("8", 47.503266, -122.200194)},
            {"9", new Customer("9", 47.591094, -122.226833)},
            {"10", new Customer("10", 47.544120, -122.221673)},
        };

        public async Task<Customer> Get(string id)
        {
            return await Task.FromResult(Customers[id]);
        }
    }
}
