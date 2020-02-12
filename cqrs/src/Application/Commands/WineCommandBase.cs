using System.Collections.Generic;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Primitives;

namespace Tba.CqrsEs.Application.Commands
{
    public abstract class WineCommandBase
    {
        private readonly IDictionary<string, StringValues> _headers;

        protected WineCommandBase(string wineId, IDictionary<string, StringValues> headers)
        {
            _headers = headers;
            WineId = wineId;
        }

        public Message Message { get; }
        public string WineId { get; }
        public int Version { get; }

    }
}