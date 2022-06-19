using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using Tba.CqrsEs.Application.Commands;
using Tba.CqrsEs.Application.Identifiers;
using Tba.CqrsEs.Application.Interfaces;

[assembly: FunctionsStartup(typeof(Tba.CqrsEs.Startup))]

namespace Tba.CqrsEs
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            
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
