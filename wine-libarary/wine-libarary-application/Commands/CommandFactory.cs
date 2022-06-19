using System;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using wine_libarary_application.Commands.RequestBodies;
using wine_libarary_application.Interfaces;

namespace wine_libarary_application.Commands
{
    public class CommandFactory : ICommandFactory
    {
        public CreateCellarCommand CreateCellarCommand(Cellar body, IDictionary<string, StringValues> headers) =>
            new CreateCellarCommand(
                body ?? throw new ArgumentNullException(nameof(Cellar)),
                headers ?? throw new ArgumentNullException(nameof(IDictionary<string, StringValues>)));

        public CloseCellarCommand CloseCellarCommand(IDictionary<string, StringValues> headers) =>
            new CloseCellarCommand(
                headers ?? throw new ArgumentNullException(nameof(IDictionary<string, StringValues>)));


        public EnterWineCommand EnterWineCommand(WineEntry body, IDictionary<string, StringValues> headers) =>
            new EnterWineCommand(
                body ?? throw new ArgumentNullException(nameof(WineEntry)),
                headers ?? throw new ArgumentNullException(nameof(IDictionary<string, StringValues>)));

        public SellWineCommand SellWineCommand(SellWineBody body, IDictionary<string, StringValues> headers)=>
            new SellWineCommand(
                body ?? throw new ArgumentNullException(nameof(SellWineBody)),
                headers ?? throw new ArgumentNullException(nameof(IDictionary<string, StringValues>)));

        public DisposeWineCommand DisposeWineCommand(DisposeWineBody body, IDictionary<string, StringValues> headers)=>
            new DisposeWineCommand(
                body ?? throw new ArgumentNullException(nameof(DisposeWineBody)),
                headers ?? throw new ArgumentNullException(nameof(IDictionary<string, StringValues>)));

        public MoveWineCommand MoveWineCommand(MoveWineBody body, IDictionary<string, StringValues> headers)=>
            new MoveWineCommand(
                body ?? throw new ArgumentNullException(nameof(MoveWineBody)),
                headers ?? throw new ArgumentNullException(nameof(IDictionary<string, StringValues>)));
    }
}