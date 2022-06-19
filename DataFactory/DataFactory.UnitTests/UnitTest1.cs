using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DataFactory.FunctionApp;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Moq;
using Xunit;

namespace DataFactory.UnitTests
{
    public class DataFactoryFunctionUnitTest
    {
        private readonly Mock<IDurableOrchestrationClient> _durableOrchestrationClientMock;
        private readonly Mock<IDurableOrchestrationContext> _durableOrchestrationContext;
        private readonly Mock<ILogger> _loggerMock;
        private readonly Mock<IDataFactoryRepository> _dataFactoryRepositoryMock;
        private readonly DataFactoryFunction _dataFactoryFunction;
        private readonly DataFactoryAccess _dfAccess;

        private const string InstanceId = "test";
        private const string CreateDataFactoryFunctionName = "CreateDataFactory";
        private const string IsPendingCreationFunctionName = "IsPendingCreation";
        private const string OrchestratorFunctionName = "DataFactoryOrchestrator";
        private const string AccessToken = "123456wasHere";
        private const string DataFactoryName = "fin-datafactory-westeurope";

        public DataFactoryFunctionUnitTest()
        {
            _loggerMock = new Mock<ILogger>();
            _durableOrchestrationClientMock = new Mock<IDurableOrchestrationClient>();
            _durableOrchestrationContext = new Mock<IDurableOrchestrationContext>();
            _dataFactoryRepositoryMock = new Mock<IDataFactoryRepository>();
            _dfAccess = new DataFactoryAccess(AccessToken, DataFactoryName);

            _dataFactoryRepositoryMock
                .Setup(_ => _.CreateAccessToken())
                .ReturnsAsync(AccessToken);

            _durableOrchestrationClientMock
                .Setup(_ => _.StartNewAsync(OrchestratorFunctionName, InstanceId, It.IsAny<object>()))
                .ReturnsAsync(InstanceId);

            _durableOrchestrationClientMock
                .Setup(_ =>
                    _.CreateCheckStatusResponse(It.IsAny<HttpRequestMessage>(), InstanceId, false))
                .Returns(HttpResponseMessage());

            _durableOrchestrationContext
                .Setup(_ => _.CallActivityAsync<string>(CreateDataFactoryFunctionName, _dfAccess))
                .ReturnsAsync(AccessToken);


            _dataFactoryFunction = new DataFactoryFunction(_dataFactoryRepositoryMock.Object);
        }

        [Fact]
        public async Task DataFactoryStarter_Should_Produce_RetryAfter_Header()
        {
            // act
            var result = await _dataFactoryFunction.DataFactoryStarter(HttpRequestMessage(),
                _durableOrchestrationClientMock.Object,
                OrchestratorFunctionName,
                InstanceId,
                _loggerMock.Object);

            // assert
            Assert.NotNull(result.Headers.RetryAfter);
            Assert.Equal(TimeSpan.FromSeconds(10), result.Headers.RetryAfter.Delta);
        }

        [Fact]
        public async Task DataFactoryOrchestrator_Should()
        {
            var result = _dataFactoryFunction.RunOrchestrator(_durableOrchestrationContext.Object);


        }

        private static HttpResponseMessage HttpResponseMessage() => new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(string.Empty),
            Headers =
            {
                RetryAfter = new RetryConditionHeaderValue(TimeSpan.FromSeconds(10))
            }
        };

        private static HttpRequestMessage HttpRequestMessage() => new HttpRequestMessage()
        {
            Content = new StringContent("{}", Encoding.UTF8, "application/json"),
            RequestUri = new Uri($"http://localhost:7071/orchestrators/{OrchestratorFunctionName}/{InstanceId}"),
        };
    }
}
