using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using wine_libarary_application.Commands.RequestBodies;

namespace wine_libarary_application.Commands
{
    public class CreateWineEntryCommand: CommandBase
    {
        public CreateWineEntryCommand(string wineId, CreateWineBody body, IDictionary<string, StringValues> headers) : base(wineId, headers)
        {
            Body = JsonConvert.SerializeObject(body);
            EventType = "WineEntryCreated";
            EventTypeVersion = "1";
        }
    }
}