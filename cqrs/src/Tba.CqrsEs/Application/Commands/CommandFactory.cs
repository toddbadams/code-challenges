using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using Tba.CqrsEs.Application.Commands.RequestBodies;
using Tba.CqrsEs.Application.Identifiers;
using Tba.CqrsEs.Application.Interfaces;

namespace Tba.CqrsEs.Application.Commands
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IIdentifierFactory _identifierFactory;

        public CommandFactory(IIdentifierFactory identifierFactory)
        {
            _identifierFactory = identifierFactory;
        }

        public CreateWineTastingCommand CreateWineTastingCommand(CreateWineTastingBody body, IDictionary<string, StringValues> headers) =>
            new CreateWineTastingCommand(_identifierFactory.Create(),
                body ?? throw new ArgumentNullException(nameof(CreateWineTastingBody)),
                headers ?? throw new ArgumentNullException(nameof(IDictionary<string, StringValues>)));

        public UpdateWineCommand UpdateWineCommand(string wineId, UpdateWineBody body, IDictionary<string, StringValues> headers) =>
            new UpdateWineCommand(wineId ?? throw new ArgumentNullException(),
                body ?? throw new ArgumentNullException(nameof(UpdateWineBody)),
                headers ?? throw new ArgumentNullException(nameof(IDictionary<string, StringValues>)));
    }
}