using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using wine_libarary_application.Commands;
using wine_libarary_application.Commands.RequestBodies;

namespace wine_libarary_application.Interfaces
{
    public interface ICommandFactory
    {
        CreateCellarCommand CreateCellarCommand(Cellar body, IDictionary<string, StringValues> headers);
        CloseCellarCommand CloseCellarCommand(IDictionary<string, StringValues> headers);

        EnterWineCommand EnterWineCommand(WineEntry body, IDictionary<string, StringValues> headers);
        SellWineCommand SellWineCommand(SellWineBody body, IDictionary<string, StringValues> headers);
        DisposeWineCommand DisposeWineCommand(DisposeWineBody body, IDictionary<string, StringValues> headers);
        MoveWineCommand MoveWineCommand(MoveWineBody body, IDictionary<string, StringValues> headers);
    }
}