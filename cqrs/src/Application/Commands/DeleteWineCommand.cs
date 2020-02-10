using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace Tba.CqrsEs.Application.Commands
{
    public class DeleteWineCommand : WineCommand
    {
        public DeleteWineCommand(string wineId, IDictionary<string, StringValues> headers) : base(wineId, headers)
        {
        }
    }
}