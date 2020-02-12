using FluentAssertions;
using Tba.CqrsEs.Application;
using Tba.CqrsEs.Application.Interfaces;
using Xunit;

namespace Tba.CqrsEs.Tests
{
    public class IdentifierFactoryTests
    {
        private readonly IIdentifierFactory _factory;

        public IdentifierFactoryTests()
        {
            _factory = new IdentifierFactory();
        }

        [Fact]
        public void Create_Should_Create_Id_With_Six_Characters() => _factory.Create().Length.Should().Be(6);

        [Theory]
        [InlineData("/")]
        [InlineData("+")]
        public void Create_Should_Create_Id_WITHOUT(string x)
        {
            _factory.Create().Should().NotContain(x);
        }
    }
}
