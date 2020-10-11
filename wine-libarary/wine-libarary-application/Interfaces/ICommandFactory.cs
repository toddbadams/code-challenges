using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using wine_libarary_application.Commands;
using wine_libarary_application.Commands.RequestBodies;

namespace wine_libarary_application.Interfaces
{
    public interface ICommandFactory
    {
        CreateCellarCommand CreateCellarCommand(CreateCellar body, IDictionary<string, StringValues> headers);
        CloseCellarCommand CloseCellarCommand(IDictionary<string, StringValues> headers);

        CreateWineEntryCommand CreateWineCommand(CreateWineBody body, IDictionary<string, StringValues> headers);
        UpdateWineCommand UpdateWineCommand(string wineId, UpdateWineBody body, IDictionary<string, StringValues> headers);
    }
}