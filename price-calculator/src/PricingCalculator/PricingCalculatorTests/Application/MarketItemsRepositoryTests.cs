using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using PricingCalculator.Application;
using PricingCalculator.Domain.Entities;
using Xunit;

namespace PricingCalculatorTests.Application
{
    public class MarketItemsRepositoryTests
    {
        private readonly MarketItemsRepository _marketItemsRepository;

        public MarketItemsRepositoryTests()
        {
            _marketItemsRepository = new MarketItemsRepository();
        }

        [Theory]
        [ClassData(typeof(InvalidItemsTestData))]
        public void Get_Should_Throw_Given_Invalid_Items(string[] items)
        {
            // arrange
            Action act = () => _marketItemsRepository.Get(items);

            // assert
            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [ClassData(typeof(ValidItemsTestData))]
        public void Get_Should_Produce_Expected_Given_Valid_Items(string[] items, IDictionary<string, MarketItem> expected)
        {
            // act 
            var result = _marketItemsRepository.Get(items);

            // assert
            result.Count.Should().Be(expected.Count);
            foreach (var item in result)
            {
                expected.Should().ContainKey(item.Key);
            }
        }

        [Fact]
        public void Get_Should_Increase_Quantity_Given_Multiples_Of_Valid_Items()
        {
            // act 
            var result = _marketItemsRepository.Get(new[] { "Apples", "Apples" });

            // assert
            result.Count.Should().Be(1);
            result.Values.First().Quantity.Should().Be(2);
        }

        public class InvalidItemsTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { null };
                yield return new object[] { new string[0] };
                yield return new object[] { new[] { "NotValid" } };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class ValidItemsTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    new[] {Milk.UniqueName, Beans.UniqueName, Bread.UniqueName, Apples.UniqueName},
                    new Dictionary<string, MarketItem>
                    {
                        {Milk.UniqueName, Milk},
                        {Beans.UniqueName, Beans},
                        {Bread.UniqueName, Bread},
                        {Apples.UniqueName, Apples}
                    },
                };
                yield return new object[]
                {
                    new[] {Beans.UniqueName},
                    new Dictionary<string, MarketItem>
                    {
                        {Beans.UniqueName, Beans}
                    },
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private static MarketItem Milk => new MarketItem("Milk", 1.30);
        private static MarketItem Beans => new MarketItem("Beans", 0.65);
        private static MarketItem Bread => new MarketItem("Bread", 0.80);
        private static MarketItem Apples => new MarketItem("Apples", 1.00, 0.1);
    }
}
