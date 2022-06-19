
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Tba.Sql
{
    public class WidgetRepository : IWidgetRepository, IDisposable
    {
        private readonly SqlConnection conn;

        public WidgetRepository(string connectionString, string accessToken)
        {
            conn = new SqlConnection(connectionString)
            {
                AccessToken = accessToken
            };
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public async Task<string> GetWidget(string id)
        {
            var statement = $"select top 1 LastName from Sales.Customer";

            using SqlCommand cmd = new SqlCommand(statement, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (await reader.ReadAsync())
            {
                return reader.GetString(0);
            }
            return null;
        }
    }

    public interface IWidgetRepository
    {
        public Task<string> GetWidget(string id);
    }
}
