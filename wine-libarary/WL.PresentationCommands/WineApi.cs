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
    public class WineApi
    {
        private readonly ICommandFactory _commandFactory;
        private readonly IRequestProcessor _requestProcessor;
        private const string Name = "wines";
        private const string TopicName = "events";
        private const string SbConnection = "TopicSend";

        public WineApi(ICommandFactory commandFactory, IRequestProcessor requestProcessor)
        {
            _commandFactory = commandFactory;
            _requestProcessor = requestProcessor;
        }

        [FunctionName(Name + "-enter")]
        public async Task<IActionResult> Enter(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [ServiceBus(TopicName, Connection = SbConnection)] IAsyncCollector<Message> messages) =>
            await _requestProcessor.ProcessRequest(Name,
                async () => _commandFactory.EnterWineCommand(await _requestProcessor.ReadBodyAsync<WineEntry>(req), req.Headers),
                messages);

        [FunctionName(Name + "-sell")]
        public async Task<IActionResult> Sell(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = Name + ".sell")] HttpRequest req,
            [ServiceBus(TopicName, Connection = SbConnection)] IAsyncCollector<Message> messages) =>
            await _requestProcessor.ProcessRequest(Name,
                async () => _commandFactory.SellWineCommand(await _requestProcessor.ReadBodyAsync<SellWineBody>(req), req.Headers),
                messages);

        [FunctionName(Name + "-dispose")]
        public async Task<IActionResult> Dispose(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = Name + ".dispose")] HttpRequest req,
            [ServiceBus(TopicName, Connection = SbConnection)] IAsyncCollector<Message> messages) =>
            await _requestProcessor.ProcessRequest(Name,
                async () => _commandFactory.DisposeWineCommand(await _requestProcessor.ReadBodyAsync<DisposeWineBody>(req), req.Headers),
                messages);
        
        [FunctionName(Name + "-move")]
        public async Task<IActionResult> Move(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = Name + ".move")] HttpRequest req,
            [ServiceBus(TopicName, Connection = SbConnection)] IAsyncCollector<Message> messages) =>
            await _requestProcessor.ProcessRequest(Name,
                async () => _commandFactory.MoveWineCommand(await _requestProcessor.ReadBodyAsync<MoveWineBody>(req), req.Headers),
                messages);
    }
}
