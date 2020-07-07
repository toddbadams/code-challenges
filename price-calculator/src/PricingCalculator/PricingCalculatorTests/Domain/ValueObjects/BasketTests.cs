using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using PricingCalculator.Domain.Entities;
using PricingCalculator.Domain.ValueObjects;
using Xunit;

namespace PricingCalculatorTests.Domain.ValueObjects
{
    public class BasketTests
    {
        [Theory]
        [ClassData(typeof(InvalidItemsTestData))]
        public void Ctor_Should_Throw_Given_Invalid_Items(IDictionary<string, MarketItem> items)
        {
            // arrange
            Action act = () => new Basket(items);

            // assert
            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [ClassData(typeof(ValidItemsTestData))]
        public void ToString_Should_Produce_Expected_Given_Valid_Items(Dictionary<string, MarketItem> items, string expected)
        {
            // arrange
            var basket = new Basket(items);

            // act 
            var result = basket.ToString();

            // act & assert
            result.Should().Be(expected);
        }

        public class InvalidItemsTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { null };
                yield return new object[] { new Dictionary<string, MarketItem>() };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class ValidItemsTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return ValidData(new List<MarketItem> { MilkX2 },
                    "Subtotal: £2.60\r\n(No offers available)\r\nTotal Price: £2.60");

                yield return ValidData(new List<MarketItem> { Apples, Milk, Bread },
                    "Subtotal: £3.10\r\nApples 10% off: -10p\r\nTotal Price: £3.00");

                yield return ValidData(new List<MarketItem> { Apples },
                    "Subtotal: £1.00\r\nApples 10% off: -10p\r\nTotal Price: 90p");

                yield return ValidData(new List<MarketItem> { Milk, Beans },
                    "Subtotal: £1.95\r\n(No offers available)\r\nTotal Price: £1.95");

                yield return ValidData(new List<MarketItem> { Milk },
                    "Subtotal: £1.30\r\n(No offers available)\r\nTotal Price: £1.30");

                yield return ValidData(new List<MarketItem> { Beans },
                    "Subtotal: 65p\r\n(No offers available)\r\nTotal Price: 65p");

            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private static object[] ValidData(IEnumerable<MarketItem> items, string expected) =>
            new object[]
            {
                items.ToDictionary(_ => _.UniqueName),
                expected
            };

        private static MarketItem Milk => new MarketItem("Milk", 1.30);
        private static MarketItem MilkX2 => new MarketItem("Milk", 1.30).AddToQuantity();
        private static MarketItem Beans => new MarketItem("Beans", 0.65);
        private static MarketItem Bread => new MarketItem("Bread", 0.80);
        private static MarketItem Apples => new MarketItem("Apples", 1.00, 0.1);
    }
}
