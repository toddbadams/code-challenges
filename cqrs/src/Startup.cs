using System;
using System.Reflection;
using AzureFunctions.Extensions.Swashbuckle;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Tba.CqrsEs.Application;
using Tba.CqrsEs.Application.Commands;
using Tba.CqrsEs.Application.Interfaces;

namespace Tba.CqrsEs
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddSwashBuckle(Assembly.GetExecutingAssembly());
            Configure(new FunctionsHostBuilder(builder.Services));
        }

        private static void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IIdentifierFactory, IdentifierFactory>();
            builder.Services.AddSingleton<ICommandFactory, CommandFactory>();
            builder.Services.AddLogging();
        }

        internal class FunctionsHostBuilder : IFunctionsHostBuilder
        {
            public FunctionsHostBuilder(IServiceCollection services)
            {
                var serviceCollection = services;
                Services = serviceCollection ?? throw new ArgumentNullException(nameof(services));
            }

            public IServiceCollection Services { get; }
        }
    }
}
