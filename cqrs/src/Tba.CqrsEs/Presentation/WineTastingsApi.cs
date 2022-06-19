using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tba.CqrsEs.Application.ClientModels;
using Tba.CqrsEs.Application.Commands;
using Tba.CqrsEs.Application.Commands.RequestBodies;
using Tba.CqrsEs.Application.Interfaces;

namespace Tba.CqrsEs.Presentation
{
    public class WineTastingsApi
    {
        private readonly ICommandFactory _commandFactory;
        private const string Name = "winetastings";
        private const string ServiceBusQueueName = "winetastings";
        private const string ServiceBusConnection = "TopicSent";

        public WineTastingsApi(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        [FunctionName(Name + "-create")]
        public async Task<IActionResult> Post(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = Name)]
            HttpRequest req,
            [ServiceBus(ServiceBusQueueName, Connection = ServiceBusConnection)]
            IAsyncCollector<ServiceBusMessage> messages) => await ProcessRequest(
                async () => _commandFactory.CreateWineTastingCommand(await ReadBodyAsync<CreateWineTastingBody>(req), req.Headers),
                messages);

        [FunctionName(Name + "-update-appearance")]
        public async Task<IActionResult> Put(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = Name + "/{wineId}")]
            HttpRequest req,
            string wineId,
            [ServiceBus(ServiceBusQueueName, Connection = ServiceBusConnection)]
            IAsyncCollector<ServiceBusMessage> messages) => await ProcessRequest(
                async () => _commandFactory.UpdateWineCommand(wineId, await ReadBodyAsync<UpdateWineTastingAppearanceBody>(req), req.Headers),
                messages);

        private static async Task<IActionResult> ProcessRequest(Func<Task<WineCommandBase>> func, IAsyncCollector<ServiceBusMessage> messages)
        {
            try
            {
                var cmd = await func();
                await messages.AddAsync(cmd.Message);
                var response = new AcceptedResponse(cmd.WineId, cmd.Version);
                return new AcceptedResult(new Uri($"{Name}/{response.Id}", UriKind.Relative), response);
            }
            catch (Exception)
            {
                return new BadRequestObjectResult(new ErrorResponse(null, 0, "Failed to process request."));
            }
        }

        private static async Task<T> ReadBodyAsync<T>(HttpRequest req)
        {
            T model;
            using (var sr = new StreamReader(req.Body))
                model = Deserialize<T>(await sr.ReadToEndAsync());
            Validate(model);
            return model;
        }

        private static T Deserialize<T>(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentNullException();
            return JsonConvert.DeserializeObject<T>(text);
        }

        private static T Validate<T>(T model)
        {
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(model, context, results))
                throw new Exception("Model is not valid because " + string.Join(", ", results.Select(s => s.ErrorMessage).ToArray()));

            return model;
        }
    }
}
