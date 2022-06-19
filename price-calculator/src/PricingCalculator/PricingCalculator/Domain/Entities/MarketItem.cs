using System;

namespace PricingCalculator.Domain.Entities
{
    public class MarketItem
    {
        public string UniqueName { get; }
        public double UnitSell { get; }
        public int Quantity { get; private set; }

        public MarketItem(string uniqueName, double unitSell, double percentDiscount = 0)
        {
            UniqueName = !string.IsNullOrWhiteSpace(uniqueName) ? uniqueName : throw new ArgumentException(nameof(uniqueName));
            UnitSell = unitSell;
            Quantity = 1;
            PercentDiscount = percentDiscount;
        }

        public double Price => Math.Round(UnitSell * Quantity, 2);
        public double Discount => Math.Round(PercentDiscount * UnitSell * Quantity, 2);
        public double PercentDiscount { get; protected set; }

        public MarketItem AddToQuantity()
        {
            Quantity++;
            return this;
        }

        public void SetPercentDiscount(double percentDiscount) => PercentDiscount = percentDiscount;
    }
}
