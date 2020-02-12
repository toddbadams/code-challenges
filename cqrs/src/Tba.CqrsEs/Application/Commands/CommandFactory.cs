using System;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using Tba.CqrsEs.Application.Commands.RequestBodies;
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

        public CreateWineCommand CreateWineCommand(CreateWineBody body, IDictionary<string, StringValues> headers) =>
            new CreateWineCommand(_identifierFactory.Create(),
                body ?? throw new ArgumentNullException(nameof(CreateWineBody)),
                headers ?? throw new ArgumentNullException(nameof(IDictionary<string, StringValues>)));

        public UpdateWineCommand UpdateWineCommand(string wineId, UpdateWineBody body, IDictionary<string, StringValues> headers) =>
            new UpdateWineCommand(wineId ?? throw new ArgumentNullException(), 
                body ?? throw new ArgumentNullException(nameof(UpdateWineBody)), 
                headers ?? throw new ArgumentNullException(nameof(IDictionary<string, StringValues>)));
    }
}