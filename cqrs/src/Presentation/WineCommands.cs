using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using Tba.CqrsEs.Application.ClientModels;
using Tba.CqrsEs.Application.Commands;
using Tba.CqrsEs.Application.Interfaces;

namespace Tba.CqrsEs
{
    public class WineApi
    {
        private readonly ICommandFactory _commandFactory;
        private const string Name = "wines";

        public WineApi(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        [FunctionName(Name + "-post")]
        public async Task<IActionResult> Post(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]
            HttpRequest req,
            [ServiceBus("events", Connection = "TopicSend")]
            IAsyncCollector<Message> messages) =>
            await ProcessRequest(
                async () => _commandFactory.CreateWineCommand(await ReadBodyAsync<CreateWineBody>(req), req.Headers),
                messages);

        [FunctionName(Name + "-put")]
        public async Task<IActionResult> Put(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = Name + "/{wineId}")]
            HttpRequest req,
            string wineId,
            [ServiceBus("events", Connection = "TopicSend")]
            IAsyncCollector<Message> messages) =>
            await ProcessRequest(
                async () => _commandFactory.UpdateWineCommand(wineId, await ReadBodyAsync<UpdateWineBody>(req), req.Headers),
                messages);

        [FunctionName(Name + "-delete")]
        public async Task<IActionResult> Delete(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = Name + "/{wineId}")]
            HttpRequest req,
            string wineId,
            [ServiceBus("events", Connection = "TopicSend")]
            IAsyncCollector<Message> messages) =>
            await ProcessRequest(
                func: () => _commandFactory.DeleteWineCommand(wineId, req.Headers),
                messages);


        private static async Task<IActionResult> ProcessRequest(Func<Task<WineCommand>> func, IAsyncCollector<Message> messages)
        {
            try
            {
                var cmd = await func();
                await messages.AddAsync(cmd.Message);
                var response = new AcceptedResponse(cmd.WineId, cmd.Version);
                return new AcceptedResult(new Uri($"wines/{response.Id}", UriKind.Relative), response);
            }
            catch (Exception)
            {
                return new BadRequestObjectResult(new ErrorResponse(null, 0, "Failed to process request."));
            }
        }

        private static async Task<IActionResult> ProcessRequest(Func<WineCommand> func, IAsyncCollector<Message> messages)
        {
            try
            {
                var cmd = func();
                await messages.AddAsync(cmd.Message);
                var response = new AcceptedResponse(cmd.WineId, cmd.Version);
                return new AcceptedResult(new Uri($"wines/{response.Id}", UriKind.Relative), response);
            }
            catch (Exception)
            {
                return new BadRequestObjectResult(new ErrorResponse(null, 0, "Failed to process request."));
            }
        }

        private static async Task<T> ReadBodyAsync<T>(HttpRequest req)
        {
            T body;
            using (var sr = new StreamReader(req.Body))
                body = Deserialize<T>(await sr.ReadToEndAsync());
            return body;
        }

        private static T Deserialize<T>(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentNullException();
            var model = JsonConvert.DeserializeObject<T>(text);
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(model, context, results))
                throw new Exception("Model is not valid because " + string.Join(", ", results.Select(s => s.ErrorMessage).ToArray()));

            return model;
        }
    }
}
