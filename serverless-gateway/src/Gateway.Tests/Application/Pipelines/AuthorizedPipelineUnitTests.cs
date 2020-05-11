using System.Net.Http;
using System.Threading.Tasks;
using Gateway.Application.Contexts;
using Gateway.Application.Interfaces;
using Gateway.Application.Middleware;
using Gateway.Application.Pipelines;
using Moq;
using Xunit;

namespace Gateway.Tests.Application.Pipelines
{
    public class AuthorizedPipelineUnitTests
    {
        private const string DownstreamKey = "key";
        private const string Uri = "http://localhost";

        private readonly Mock<IContextFactory> _contextFactoryMock;
        private readonly Mock<IMiddlewareFactory> _middlewareFactoryMock;
        private readonly Mock<MiddlewareBase> _middlewareMock;
        private readonly HttpRequestMessage _requestMessage;
        private readonly Pipeline _pipeline;

        public AuthorizedPipelineUnitTests()
        {
            var contextMock = new Mock<IContext>();
            _contextFactoryMock = new Mock<IContextFactory>();
            _contextFactoryMock.Setup(_ => _.Create(It.IsAny<string>(), It.IsAny<HttpRequestMessage>()))
                .Returns(contextMock.Object);

            _middlewareMock = new Mock<MiddlewareBase>();
            _middlewareFactoryMock = new Mock<IMiddlewareFactory>();
            _middlewareFactoryMock.Setup(_ => _.CorrelationId()).Returns(_middlewareMock.Object);
            _middlewareFactoryMock.Setup(_ => _.FunctionHostKey()).Returns(_middlewareMock.Object);

            _requestMessage = new HttpRequestMessage(HttpMethod.Get, Uri);

            _pipeline = new AuthorizedPipeline(_contextFactoryMock.Object, _middlewareFactoryMock.Object);
        }

        [Fact]
        public void Ctor_should_register_CorrelationId_middleware()
        {
            // assert
            _middlewareFactoryMock.Verify(_ => _.CorrelationId(), Times.Once);

        }

        [Fact]
        public void Ctor_should_register_FunctionHostKey_middleware()
        {
            // assert
            _middlewareFactoryMock.Verify(_ => _.FunctionHostKey(), Times.Once);

        }

        [Fact]
        public async Task ExecuteAsync_should_create_context()
        {
            // act
            await _pipeline.ExecuteAsync(DownstreamKey, _requestMessage);

            // assert
            _contextFactoryMock.Verify(_ => _.Create(DownstreamKey, _requestMessage), Times.Once);
        }

        [Fact]
        public async Task ExecuteAsync_should_call_middleware_InvokeAsync()
        {
            // act
            await _pipeline.ExecuteAsync(DownstreamKey, _requestMessage);

            // assert
            _middlewareMock.Verify(_ => _.InvokeAsync(It.IsAny<IContext>()), Times.Exactly(2));
        }
    }
}
