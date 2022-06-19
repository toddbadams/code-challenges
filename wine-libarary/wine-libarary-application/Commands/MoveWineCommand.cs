using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using wine_libarary_application.Commands.RequestBodies;

namespace wine_libarary_application.Commands
{
    public class MoveWineCommand : CommandBase
    {
        public MoveWineCommand(MoveWineBody body, IDictionary<string, StringValues> headers) : base(headers)
        {
            Body = JsonConvert.SerializeObject(body);
            EventType = "WineMoved";
            EventTypeVersion = "1";
        }
    }
}