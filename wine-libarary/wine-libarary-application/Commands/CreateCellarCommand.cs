using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using wine_libarary_application.Commands.RequestBodies;

namespace wine_libarary_application.Commands
{
    public class CreateCellarCommand : CommandBase
    {
        public CreateCellarCommand(Cellar body, IDictionary<string, StringValues> headers) : base(headers)
        {
            Body = JsonConvert.SerializeObject(body);
            EventType = "CellarCreated";
            EventTypeVersion = "1";
        }
    }
}