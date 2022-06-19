using Microsoft.Extensions.Primitives;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using Tba.CqrsEs.Application.Commands;
using Tba.CqrsEs.Application.Commands.RequestBodies;
using Tba.CqrsEs.Application.Identifiers;
using Tba.CqrsEs.Application.Interfaces;
using Xunit;

namespace Tba.CqrsEs.Tests.Application.Commands
{
    public class CommandFactoryTests
    {
        private const string ID = "123456";
        private readonly ICommandFactory _factory;

        public CommandFactoryTests()
        {
            var identifierFactory = new Mock<IIdentifierFactory>();
            identifierFactory.Setup(_ => _.Create()).Returns(ID);
            _factory = new CommandFactory(identifierFactory.Object);
        }

        [Theory]
        [ClassData(typeof(CreateWineCommandTestData))]
        public void CreateWineCommand_Should_Throw_Null_Argument_Given_NullParameters(CreateWineTastingBody body,
            IDictionary<string, StringValues> headers) =>
            Assert.Throws<ArgumentNullException>(() => _factory.CreateWineTastingCommand(body, headers));

        private class CreateWineCommandTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new CreateWineTastingBody(), null };
                yield return new object[] { null, new Dictionary<string, StringValues>() };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        [Theory]
        [ClassData(typeof(UpdateWineCommandTestData))]
        public void UpdateWineCommand_Should_Throw_Null_Argument_Given_NullParameters(string wineId, UpdateWineBody body,
            IDictionary<string, StringValues> headers)
        {
            Assert.Throws<ArgumentNullException>(() => _factory.UpdateWineCommand(wineId, body, headers));
        }

        private class UpdateWineCommandTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { ID, new UpdateWineBody(), null };
                yield return new object[] { ID, null, new Dictionary<string, StringValues>() };
                yield return new object[] { null, new UpdateWineBody(), new Dictionary<string, StringValues>() };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}