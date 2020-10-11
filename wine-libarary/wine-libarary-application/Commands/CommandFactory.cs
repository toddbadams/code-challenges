using System;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using wine_libarary_application.Commands.RequestBodies;
using wine_libarary_application.Identifiers;
using wine_libarary_application.Interfaces;

namespace wine_libarary_application.Commands
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IIdentifierFactory _identifierFactory;

        public CommandFactory(IIdentifierFactory identifierFactory)
        {
            _identifierFactory = identifierFactory;
        }

        public CreateCellarCommand CreateCellarCommand(CreateCellar body, IDictionary<string, StringValues> headers)
        {
            throw new NotImplementedException();
        }

        public CloseCellarCommand CloseCellarCommand(IDictionary<string, StringValues> headers)
        {
            throw new NotImplementedException();
        }

        public CreateWineEntryCommand CreateWineEntryCommand(CreateWineBody body, IDictionary<string, StringValues> headers) =>
            new CreateWineEntryCommand(_identifierFactory.Create(),
                body ?? throw new ArgumentNullException(nameof(CreateWineBody)),
                headers ?? throw new ArgumentNullException(nameof(IDictionary<string, StringValues>)));

        public UpdateWineCommand UpdateWineCommand(string wineId, UpdateWineBody body, IDictionary<string, StringValues> headers) =>
            new UpdateWineCommand(wineId ?? throw new ArgumentNullException(), 
                body ?? throw new ArgumentNullException(nameof(UpdateWineBody)), 
                headers ?? throw new ArgumentNullException(nameof(IDictionary<string, StringValues>)));
    }
}