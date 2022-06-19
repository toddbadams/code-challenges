
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Services.AppAuthentication;
using System.Configuration;

[assembly: FunctionsStartup(typeof(Tba.Sql.Startup))]
namespace Tba.Sql
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // The singleton service lifetime matches the host lifetime and is reused across function executions on that instance.
            builder.Services.AddSingleton<IWidgetRepository>((s) => {
                var tokenProvider = new AzureServiceTokenProvider();
                var accessToken = tokenProvider.GetAccessTokenAsync("https://database.windows.net/").Result;
                var connectionString = ConfigurationManager.ConnectionStrings["sqlConnection"].ConnectionString;

                return new WidgetRepository(connectionString, accessToken);
            });
        }
    }
}
