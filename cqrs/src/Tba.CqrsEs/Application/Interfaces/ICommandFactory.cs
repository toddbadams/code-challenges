using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using Tba.CqrsEs.Application.Commands;
using Tba.CqrsEs.Application.Commands.RequestBodies;

namespace Tba.CqrsEs.Application.Interfaces
{
    public interface ICommandFactory
    {
        CreateWineCommand CreateWineCommand(CreateWineBody body, IDictionary<string, StringValues> headers);
        UpdateWineCommand UpdateWineCommand(string wineId, UpdateWineBody body, IDictionary<string, StringValues> headers);
    }
}