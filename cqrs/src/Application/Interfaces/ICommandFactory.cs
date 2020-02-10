using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using Tba.CqrsEs.Application.Commands;

namespace Tba.CqrsEs.Application.Interfaces
{
    public interface ICommandFactory
    {
        CreateWineCommand CreateWineCommand(CreateWineBody body, IDictionary<string, StringValues> headers);
        UpdateWineCommand UpdateWineCommand(string wineId, UpdateWineBody body, IDictionary<string, StringValues> headers);
        DeleteWineCommand DeleteWineCommand(string wineId, IDictionary<string, StringValues> headers);
    }
}