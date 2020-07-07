using System.Collections.Generic;
using FluentAssertions;
using PricingCalculator.Domain.Entities;
using PricingCalculator.Domain.Services;
using Xunit;

namespace PricingCalculatorTests.Domain.Services
{
    public class BuyGetDiscountServiceTests
    {

        private BuyGetDiscountService _buyGetDiscountService;

        [Fact]
        public void Process_Should_NOT_Change_Bread_PercentDiscount_Given_Beans_Not_Present()
        {
            // arrange
            _buyGetDiscountService = BeansDiscountService;
            var items = ItemsWithoutBeans;

            // act
            _buyGetDiscountService.Process(items);

            // assert
            items["Bread"].PercentDiscount.Should().Be(0);
        }

        [Fact]
        public void Process_Should_NOT_Change_Bread_PercentDiscount_Given_Beans_Present_Once()
        {
            // arrange
            _buyGetDiscountService = BeansDiscountService;
            var items = ItemsWithoutBeans;
            items.Add(Beans.UniqueName, Beans);

            // act
            _buyGetDiscountService.Process(items);

            // assert
            items["Bread"].PercentDiscount.Should().Be(0);
        }

        [Fact]
        public void Process_Should_Change_Bread_PercentDiscount_Given_Beans_Present_Twice()
        {
            // arrange
            _buyGetDiscountService = BeansDiscountService;
            var items = ItemsWithoutBeans;
            items.Add(BeansX2.UniqueName, BeansX2);

            // act
            _buyGetDiscountService.Process(items);

            // assert
            items["Bread"].PercentDiscount.Should().Be(0.5);
        }

        private static BuyGetDiscountService BeansDiscountService => new BuyGetDiscountService("Beans", 2, "Bread", 0.5);

        private static IDictionary<string, MarketItem> ItemsWithoutBeans => new Dictionary<string, MarketItem>
        {
            {Milk.UniqueName, Milk},
            {Bread.UniqueName, Bread},
            {Apples.UniqueName, Apples}
        };

        private static MarketItem Milk => new MarketItem("Milk", 1.30);
        private static MarketItem Beans => new MarketItem("Beans", 0.65);
        private static MarketItem BeansX2 => new MarketItem("Beans", 0.65).AddToQuantity();
        private static MarketItem Bread => new MarketItem("Bread", 0.80);
        private static MarketItem Apples => new MarketItem("Apples", 1.00, 0.1);
    }
}
