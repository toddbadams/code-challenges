using System;
using FluentAssertions;
using PricingCalculator.Domain.Entities;
using Xunit;

namespace PricingCalculatorTests.Domain.Entities
{
    public class MarketItemTests
    {
        private readonly string _uniqueName;
        private readonly double _unitSell;
        private readonly MarketItem _marketItem;
        private readonly double _percentDiscount;

        public MarketItemTests()
        {
            var random = new Random();
            _percentDiscount = random.NextDouble();
            _uniqueName = Guid.NewGuid().ToString();
            _unitSell = random.NextDouble() * 100;
            _marketItem = new MarketItem(_uniqueName, _unitSell, _percentDiscount);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Ctor_Should_Throw_Given_Invalid_UniqueName(string value)
        {
            // arrange
            Action act = () => new MarketItem(value, _unitSell);

            // assert
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Ctor_Should_Set_UniqueName_Given_UniqueName() => _marketItem.UniqueName.Should().Be(_uniqueName);

        [Fact]
        public void Ctor_Should_Set_UnitSell_Given_UnitSell() => _marketItem.UnitSell.Should().Be(_unitSell);

        [Fact]
        public void Ctor_Should_Set_Quantity() => _marketItem.Quantity.Should().Be(1);

        [Fact]
        public void AddToQuantity_Should_Increase_Quantity_By_One()
        {
            // act
            _marketItem.AddToQuantity();

            // assert
            _marketItem.Quantity.Should().Be(2);
        }

        [Fact]
        public void Ctor_Should_Set_PercentDiscount_Given_PercentDiscount() => _marketItem.PercentDiscount.Should().Be(_percentDiscount);

        [Fact]
        public void Discount_Should_Return_Discount() => _marketItem.Discount.Should().Be(Math.Round(_percentDiscount * _unitSell, 2));

        [Fact]
        public void Discount_Should_Return_Discount_Given_Quantity_2() => _marketItem.AddToQuantity().Discount.Should().Be(Math.Round(_percentDiscount * _unitSell * 2, 2));

        [Fact]
        public void SetPercentDiscount_Should_Set_PercentDiscount()
        {
            // act
            _marketItem.SetPercentDiscount(0.99);

            // assert
            _marketItem.PercentDiscount.Should().Be(0.99);
        }
    }
}
