using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Gateway.Application.Contexts;
using Gateway.Application.Interfaces;
using Moq;
using Moq.Protected;
using Xunit;

namespace Gateway.Tests.Application.Context
{
    public class ContextUnitTests
    {
        private const string DownstreamKey = "key";
        private const string Uri = "http://localhost";
        private const string Scheme = "http";
        private const string Host = "localhost";
        private const string Port = "666";
        private const string Route = "/route";
        private const string JsonContent = @"{'Name': 'name', 'Count': 23}";

        private readonly HttpRequestMessage _requestMessage;
        private readonly HttpClient _httpClient;
        private readonly IContext _context;

        public ContextUnitTests()
        {
            var configurationProviderMock = new Mock<IConfigurationProvider>();
            configurationProviderMock.Setup(_ => _.Get($"{DownstreamKey}-scheme")).Returns(Scheme);
            configurationProviderMock.Setup(_ => _.Get($"{DownstreamKey}-host")).Returns(Host);
            configurationProviderMock.Setup(_ => _.Get($"{DownstreamKey}-port")).Returns(Port);
            configurationProviderMock.Setup(_ => _.Get($"{DownstreamKey}-route")).Returns(Route);

            _requestMessage = new HttpRequestMessage(HttpMethod.Get, Uri) { Content = new StringContent(JsonContent) };

            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", 
                    ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonContent),
                })
                .Verifiable();
            _httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri(Uri)
            };

            _context = new Gateway.Application.Contexts.Context(_requestMessage, configurationProviderMock.Object,
                DownstreamKey, _httpClient);
        }

        [Fact]
        public void Ctor_Should_set_DownstreamKey() => _context.DownstreamKey.Should().Be(DownstreamKey);

        [Fact]
        public void Ctor_Should_set_HttpClient() => _context.HttpClient.Should().Be(_httpClient);

        [Fact]
        public void Ctor_Should_set_Request() => _context.Request.Should().Be(_requestMessage);

        [Fact]
        public void Ctor_Should_create_DownstreamRequest() => _context.DownstreamRequest.Should().NotBeNull();

        [Fact]
        public void Ctor_Should_set_DownstreamRequest_Uri() => _context.DownstreamRequest.RequestUri.Should()
            .Be($"{Scheme}://{Host}:{Port}{Route}");

        [Fact]
        public void Ctor_Should_set_DownstreamRequest_Method() => _context.DownstreamRequest.Method.Should()
            .Be(_requestMessage.Method);

        [Fact]
        public async Task Ctor_Should_set_DownstreamRequest_Content()
        {
            // assert
            var content = await _context.DownstreamRequest.Content.ReadAsStringAsync();
            content.Should().Be(JsonContent);
        }

        [Fact]
        public async Task SendAsync_Should_return_downstream_response()
        {
            // act
            var result = await _context.SendAsync();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
