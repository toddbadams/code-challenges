using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using Tba.CqrsEs.Application.Commands.RequestBodies;

namespace Tba.CqrsEs.Application.Commands
{
    public class CreateWineCommand: WineCommandBase
    {
        public CreateWineCommand(string wineId, CreateWineBody body, IDictionary<string, StringValues> headers) : base(wineId, headers)
        {
            
        }
    }
}