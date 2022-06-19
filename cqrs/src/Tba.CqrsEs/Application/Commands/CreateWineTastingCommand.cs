using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Collections.Generic;
using Tba.CqrsEs.Application.Commands.RequestBodies;

namespace Tba.CqrsEs.Application.Commands
{
    public class CreateWineTastingCommand : WineCommandBase
    {
        public CreateWineTastingCommand(string id, CreateWineTastingBody body, IDictionary<string, StringValues> headers) : base(id, headers)
        {
            Body = JsonConvert.SerializeObject(body);
            EventType = "WineTastingCreated";
            EventTypeVersion = "1";
        }
    }
}