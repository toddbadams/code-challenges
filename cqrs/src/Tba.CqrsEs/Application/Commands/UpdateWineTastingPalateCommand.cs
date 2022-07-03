using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Collections.Generic;
using Tba.CqrsEs.Application.Commands.RequestBodies;

namespace Tba.CqrsEs.Application.Commands
{
    public class UpdateWineTastingPalateCommand : WineCommandBase
    {
        public UpdateWineTastingPalateCommand(string wineId, UpdateWineTastingPalateBody body, IDictionary<string, StringValues> headers) : base(wineId, headers)
        {
            Body = JsonConvert.SerializeObject(body);
            EventType = "WineTastingPalateUpdated";
            EventTypeVersion = "1";
        }
    }
}