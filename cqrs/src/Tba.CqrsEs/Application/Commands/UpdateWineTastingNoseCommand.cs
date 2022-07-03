using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Collections.Generic;
using Tba.CqrsEs.Application.Commands.RequestBodies;

namespace Tba.CqrsEs.Application.Commands
{
    public class UpdateWineTastingNoseCommand : WineCommandBase
    {
        public UpdateWineTastingNoseCommand(string wineId, UpdateWineTastingNoseBody body, IDictionary<string, StringValues> headers) : base(wineId, headers)
        {
            Body = JsonConvert.SerializeObject(body);
            EventType = "WineTastingNoseUpdated";
            EventTypeVersion = "1";
        }
    }
}