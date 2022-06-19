using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using Tba.CqrsEs.Application.Commands;
using Tba.CqrsEs.Application.Commands.RequestBodies;

namespace Tba.CqrsEs.Application.Interfaces
{
    public interface ICommandFactory
    {
        CreateWineTastingCommand CreateWineTastingCommand(CreateWineTastingBody body, IDictionary<string, StringValues> headers);
        UpdateWineCommand UpdateWineCommand(string wineId, UpdateWineBody body, IDictionary<string, StringValues> headers);
    }
}