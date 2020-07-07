using System.Collections.Generic;
using PricingCalculator.Domain.Entities;

namespace PricingCalculator.Application
{
    public interface IMarketItemsRepository
    {
        IDictionary<string, MarketItem> Get(IEnumerable<string> items);
    }
}