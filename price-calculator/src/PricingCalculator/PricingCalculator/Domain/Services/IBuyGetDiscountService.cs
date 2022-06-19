using System.Collections.Generic;
using PricingCalculator.Domain.Entities;

namespace PricingCalculator.Domain.Services
{
    public interface IBuyGetDiscountService
    {
        void Process(IDictionary<string, MarketItem> items);
    }
}