using System;
using System.Collections.Generic;
using System.Text;
using PricingCalculator.Domain.Entities;

namespace PricingCalculator.Domain.ValueObjects
{
    public readonly struct Basket
    {
        private readonly IDictionary<string, MarketItem> _items;

        public Basket(IDictionary<string, MarketItem> items)
        {
            _items = items != null && items.Count > 0 ?
                items :
                throw new ArgumentException();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var subTotal = 0.0;
            var discount = 0.0;
            foreach (var item in _items.Values)
            {
                subTotal += item.Price;
                discount += item.Discount;
                if (!(item.Discount > 0)) continue;
                sb.Append($"{DiscountText(item)}{Cr}");
            }

            sb.Insert(0, $"Subtotal: {CurrencyText(subTotal)}{Cr}");
            if (discount < 0.01)
            {
                sb.Append($"(No offers available){Cr}");
            }

            sb.Append($"Total Price: {CurrencyText(subTotal - discount)}");

            return sb.ToString();
        }

        private static string Cr => "\r\n";

        private static string CurrencyText(double value) => value < 1 ? $"{value*100:F0}p" : $"{value:C2}";

        private static string DiscountText(MarketItem item) => $"{item.UniqueName} {item.PercentDiscount*100:F0}% off: -{CurrencyText(item.Discount)}";
    }
}