using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace wine_libarary_application.Commands
{
    public class CloseCellarCommand : CommandBase
    {
        public CloseCellarCommand(string wineId, IDictionary<string, StringValues> headers) : base(wineId, headers)
        {
        }
    }
}