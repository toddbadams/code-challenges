using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Gateway.Application.Contexts;
using Gateway.Application.Middleware;
using Moq;
using Xunit;

namespace Gateway.Tests.Application.Middleware
{
    public class CorrelationIdMiddlewareUnitTest
    {
        private const string Uri = "http://localhost";
        private const string RequestIdHeader = "Request-Id";

        private readonly HttpRequestMessage _requestMessage;
        private readonly HttpRequestMessage _downstreamRequestMessage;
        private readonly Mock<IContext> _contextMock;
        private readonly CorrelationIdMiddleware _middleware;

        public CorrelationIdMiddlewareUnitTest()
        {
            _contextMock = new Mock<IContext>();

            _requestMessage = new HttpRequestMessage(HttpMethod.Get, Uri);
            _contextMock.Setup(_ => _.Request).Returns(_requestMessage);

            _downstreamRequestMessage = new HttpRequestMessage(HttpMethod.Get, Uri);
            _contextMock.Setup(_ => _.DownstreamRequest).Returns(_downstreamRequestMessage);

            _middleware = new CorrelationIdMiddleware();
        }

        [Fact]
        public async Task InvokeAsync_should_create_requestId_Given_NOT_In_Request()
        {
            // act
            await _middleware.InvokeAsync(_contextMock.Object);

            // assert
            _downstreamRequestMessage.Headers.Contains(RequestIdHeader).Should().BeTrue();
        }

        [Fact]
        public async Task InvokeAsync_should_forward_requestId_Given_NOT_In_Request()
        {
            // arrange
            _requestMessage.Headers.Add(RequestIdHeader, "somerequestid");

            // act
            await _middleware.InvokeAsync(_contextMock.Object);

            // assert
            _downstreamRequestMessage.Headers.Contains(RequestIdHeader).Should().BeTrue();
            _downstreamRequestMessage.Headers.GetValues(RequestIdHeader).First().Should().Be("somerequestid");
        }
    }
}