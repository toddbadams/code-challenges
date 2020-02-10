using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
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
            new CreateWineCommand(_identifierFactory.Create(), body, headers);

        public UpdateWineCommand UpdateWineCommand(string wineId, UpdateWineBody body, IDictionary<string, StringValues> headers) => 
            new UpdateWineCommand(wineId, body, headers);

        public DeleteWineCommand DeleteWineCommand(string wineId, IDictionary<string, StringValues> headers) => 
            new DeleteWineCommand(wineId, headers);
    }
}