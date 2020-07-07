using System;
using System.Collections.Generic;
using System.Linq;
using PricingCalculator.Domain.Entities;

namespace PricingCalculator.Application
{
    public class MarketItemsRepository : IMarketItemsRepository
    {
        private readonly IDictionary<string, MarketItem> _masterItems;

        public MarketItemsRepository()
        {
            _masterItems = new Dictionary<string, MarketItem>
            {
                {"Beans", new MarketItem("Beans", 0.65)},
                {"Bread", new MarketItem("Bread", 0.80)},
                {"Milk", new MarketItem("Milk", 1.30)},
                {"Apples", new MarketItem("Apples", 1.00, 0.1)}
            };
        }

        public IDictionary<string, MarketItem> Get(IEnumerable<string> items)
        {
            if (!(items as string[] ?? Array.Empty<string>()).Any()) throw new ArgumentException();

            var results = new Dictionary<string, MarketItem>();
            foreach (var item in items)
            {
                GetItem(item, results);
            }

            return results;
        }

        private void GetItem(string item, IDictionary<string, MarketItem> results)
        {
            if (!_masterItems.ContainsKey(item)) throw new ArgumentException();

            if (results.ContainsKey(item))
            {
                results[item].AddToQuantity();
                return;
            }

            results.Add(item, _masterItems[item]);
        }
    }
}