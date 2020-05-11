using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Gateway.Application.Contexts;
using Gateway.Application.Interfaces;
using Gateway.Application.Middleware;
using Moq;
using Xunit;

namespace Gateway.Tests.Application.Middleware
{
    public class FunctionHostKeyMiddlewareUnitTest
    {
        private const string Uri = "http://localhost";
        private const string FunctionHostHeaderKey = "x-functions-key";
        private const string DownstreamKey = "key";
        private const string FunctionHostKey = "FHKey";
        private readonly HttpRequestMessage _downstreamRequestMessage;
        private readonly Mock<IContext> _contextMock;
        private readonly FunctionHostKeyMiddleware _middleware;

        public FunctionHostKeyMiddlewareUnitTest()
        {
            _contextMock = new Mock<IContext>();
            _downstreamRequestMessage = new HttpRequestMessage(HttpMethod.Get, Uri);
            _contextMock.Setup(_ => _.DownstreamRequest).Returns(_downstreamRequestMessage);
            _contextMock.Setup(_ => _.DownstreamKey).Returns(DownstreamKey);

            var secretsProviderMock = new Mock<ISecretsProvider>();
            secretsProviderMock.Setup(_ => _.Get($"{DownstreamKey}-functionHostKey")).ReturnsAsync(FunctionHostKey);

            _middleware = new FunctionHostKeyMiddleware(secretsProviderMock.Object);
        }

        [Fact]
        public async Task InvokeAsync_should_create_function_host_key()
        {
            await _middleware.InvokeAsync(_contextMock.Object);

            _downstreamRequestMessage.Headers.Contains(FunctionHostHeaderKey).Should().BeTrue();
        }
    }
}