using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace Tba.CqrsEs.Application.Commands
{
    public class UpdateWineCommand : WineCommand
    {
        public UpdateWineCommand(string wineId, UpdateWineBody body, IDictionary<string, StringValues> headers) : base(wineId, headers)
        {
        }
    }
}