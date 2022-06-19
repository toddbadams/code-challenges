using System.Collections.Generic;
using PricingCalculator.Domain.Entities;

namespace PricingCalculator.Domain.Services
{
    public class BuyGetDiscountService : IBuyGetDiscountService
    {
        private readonly string _buy;
        private readonly int _buyQuantity;
        private readonly string _discountItem;
        private readonly double _percentDiscount;

        public BuyGetDiscountService(string buy, int buyQuantity, string discountItem, double percentDiscount)
        {
            _buy = buy;
            _buyQuantity = buyQuantity;
            _discountItem = discountItem;
            _percentDiscount = percentDiscount;
        }

        public void Process(IDictionary<string, MarketItem> items)
        {
            if(!items.ContainsKey(_buy)) return;

            if (items[_buy].Quantity >= _buyQuantity && items.ContainsKey(_discountItem))
            {
                items[_discountItem].SetPercentDiscount(_percentDiscount);
            }
        }
    }
}
