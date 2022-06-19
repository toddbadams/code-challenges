using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Collections.Generic;
using Tba.CqrsEs.Application.Commands.RequestBodies;

namespace Tba.CqrsEs.Application.Commands
{
    public class UpdateWineTastingAppearanceCommand : WineCommandBase
    {
        public UpdateWineTastingAppearanceCommand(string wineId, UpdateWineTastingAppearanceBody body, IDictionary<string, StringValues> headers) : base(wineId, headers)
        {
            Body = JsonConvert.SerializeObject(body);
            EventType = "WineTastingAppearanceUpdated";
            EventTypeVersion = "1";
        }
    }
}