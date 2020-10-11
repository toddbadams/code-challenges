using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace wine_libarary_application.Commands
{
    public class CloseCellarCommand : CommandBase
    {
        public CloseCellarCommand(IDictionary<string, StringValues> headers) : base(headers)
        {
            EventType = "CellarClosed";
            EventTypeVersion = "1";
        }
    }
}