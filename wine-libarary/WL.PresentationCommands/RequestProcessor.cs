using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
using wine_libarary_application.ClientModels;
using wine_libarary_application.Commands;

namespace WL.PresentationCommands
{
    public class RequestProcessor : IRequestProcessor
    {

        public async Task<IActionResult> ProcessRequest(string name, Func<Task<CommandBase>> func, IAsyncCollector<Message> messages)
        {
            try
            {
                var cmd = await func();
                await messages.AddAsync(cmd.Message);
                var response = new AcceptedResponse(cmd.EventType, cmd.EventTypeVersion);
                return new AcceptedResult(new Uri(name, UriKind.Relative), response);
            }
            catch (Exception)
            {
                return new BadRequestObjectResult(new ErrorResponse("Failed to process request."));
            }
        }
        
        
        public async Task<IActionResult> ProcessRequest(string name, Func<CommandBase> func, IAsyncCollector<Message> messages)
        {
            try
            {
                var cmd = func();
                await messages.AddAsync(cmd.Message);
                var response = new AcceptedResponse(cmd.EventType, cmd.EventTypeVersion);
                return new AcceptedResult(new Uri(name, UriKind.Relative), response);
            }
            catch (Exception)
            {
                return new BadRequestObjectResult(new ErrorResponse("Failed to process request."));
            }
        }

        public async Task<T> ReadBodyAsync<T>(HttpRequest req)
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
                throw new Exception("Model is not valid because " +
                                    string.Join(", ", results.Select(s => s.ErrorMessage).ToArray()));

            return model;
        }
    }
}