using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace Tba.CqrsEs.Application.Commands
{
    public class CreateWineCommand: WineCommand
    {
        public CreateWineCommand(string wineId, CreateWineBody body, IDictionary<string, StringValues> headers) : base(wineId, headers)
        {
            
        }
    }
}