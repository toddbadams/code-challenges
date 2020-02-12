using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Tba.CqrsEs.Application.Commands.RequestBodies;

namespace Tba.CqrsEs.Application.Commands
{
    public class CreateWineCommand: WineCommandBase
    {
        public CreateWineCommand(string wineId, CreateWineBody body, IDictionary<string, StringValues> headers) : base(wineId, headers)
        {
            Body = JsonConvert.SerializeObject(body);
            EventType = "WineCreated";
            EventTypeVersion = "1";
        }
    }
}