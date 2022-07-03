using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using Tba.CqrsEs.Application.Commands;
using Tba.CqrsEs.Application.Commands.RequestBodies;

namespace Tba.CqrsEs.Application.Interfaces
{
    public interface ICommandFactory
    {
        CreateWineTastingCommand CreateWineTastingCommand(CreateWineTastingBody body, IDictionary<string, StringValues> headers);
        UpdateWineTastingAppearanceCommand UpdateWineCommand(string wineId, UpdateWineTastingAppearanceBody body, IDictionary<string, StringValues> headers);
        UpdateWineTastingNoseCommand UpdateWineCommand(string wineId, UpdateWineTastingNoseBody body, IDictionary<string, StringValues> headers);
        UpdateWineTastingPalateCommand UpdateWineCommand(string wineId, UpdateWineTastingPalateBody body, IDictionary<string, StringValues> headers);
    }
}