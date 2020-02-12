using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using Tba.CqrsEs.Application.Commands.RequestBodies;

namespace Tba.CqrsEs.Application.Commands
{
    public class UpdateWineCommand : WineCommandBase
    {
        public UpdateWineCommand(string wineId, UpdateWineBody body, IDictionary<string, StringValues> headers) : base(wineId, headers)
        {
        }
    }
}