using System;
using Microsoft.Extensions.DependencyInjection;
using PricingCalculator.Application;
using PricingCalculator.Domain.Services;
using PricingCalculator.Domain.ValueObjects;

namespace PricingCalculator.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IMarketItemsRepository, MarketItemsRepository>()
                .AddTransient<IBuyDiscountServiceFactory, BuyDiscountServiceFactory>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IMarketItemsRepository>();
            var beans = serviceProvider.GetService<IBuyDiscountServiceFactory>().Beans();

            try
            {
                var items = repo.Get(args);
                beans.Process(items);
                Console.WriteLine(new Basket(items));
            }
            catch
            {
                Console.WriteLine("Invalid item list");
            }

            Console.ReadLine();
        }
    }
}
