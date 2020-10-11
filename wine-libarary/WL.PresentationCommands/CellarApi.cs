using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using wine_libarary_application.Commands.RequestBodies;
using wine_libarary_application.Interfaces;

namespace WL.PresentationCommands
{
    public class CellarApi
    {
        private readonly ICommandFactory _commandFactory;
        private readonly IRequestProcessor _requestProcessor;
        private const string Name = "cellars";

        public CellarApi(ICommandFactory commandFactory, IRequestProcessor requestProcessor)
        {
            _commandFactory = commandFactory;
            _requestProcessor = requestProcessor;
        }

        [FunctionName(Name + "-create")]
        public async Task<IActionResult> Post(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [ServiceBus("events", Connection = "TopicSend")] IAsyncCollector<Message> messages) =>
            await _requestProcessor.ProcessRequest(Name,
                async () => _commandFactory.CreateCellarCommand(await _requestProcessor.ReadBodyAsync<Cellar>(req), req.Headers),
                messages);

        [FunctionName(Name + "-close")]
        public async Task<IActionResult> Put(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = Name)] HttpRequest req,
            [ServiceBus("events", Connection = "TopicSend")] IAsyncCollector<Message> messages) =>
            await _requestProcessor.ProcessRequest(Name,
                 () => _commandFactory.CloseCellarCommand(req.Headers),
                messages);
    }
}