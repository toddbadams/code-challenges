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

        public UpdateWineTastingAppearanceCommand UpdateWineCommand(string wineId, UpdateWineTastingAppearanceBody body, IDictionary<string, StringValues> headers) =>
            new UpdateWineTastingAppearanceCommand(wineId ?? throw new ArgumentNullException(),
                body ?? throw new ArgumentNullException(nameof(UpdateWineTastingAppearanceBody)),
                headers ?? throw new ArgumentNullException(nameof(IDictionary<string, StringValues>)));

        public UpdateWineTastingNoseCommand UpdateWineCommand(string wineId, UpdateWineTastingNoseBody body, IDictionary<string, StringValues> headers) =>
            new UpdateWineTastingNoseCommand(wineId ?? throw new ArgumentNullException(),
                body ?? throw new ArgumentNullException(nameof(UpdateWineTastingNoseBody)),
                headers ?? throw new ArgumentNullException(nameof(IDictionary<string, StringValues>)));

        public UpdateWineTastingPalateCommand UpdateWineCommand(string wineId, UpdateWineTastingPalateBody body, IDictionary<string, StringValues> headers) =>
            new UpdateWineTastingPalateCommand(wineId ?? throw new ArgumentNullException(),
                body ?? throw new ArgumentNullException(nameof(UpdateWineTastingPalateBody)),
                headers ?? throw new ArgumentNullException(nameof(IDictionary<string, StringValues>)));

    }
}