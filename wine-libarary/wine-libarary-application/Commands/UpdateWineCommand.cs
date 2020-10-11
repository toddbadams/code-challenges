using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using wine_libarary_application.Commands.RequestBodies;

namespace wine_libarary_application.Commands
{
    public class UpdateWineCommand : CommandBase
    {
        public UpdateWineCommand(string wineId, UpdateWineBody body, IDictionary<string, StringValues> headers) : base(wineId, headers)
        {
            Body = JsonConvert.SerializeObject(body);
            EventType = "WineUpdated";
            EventTypeVersion = "1";
        }
    }
}