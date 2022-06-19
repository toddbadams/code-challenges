using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tba.CqrsEs.Application.Commands
{
    public abstract class WineCommandBase
    {
        private readonly IDictionary<string, StringValues> _headers;

        protected string Body { private get; set; }
        protected string EventType { private get; set; }
        protected string EventTypeVersion { private get; set; }

        private const string AggregateType = "WineTasting";
        private const string AggregateTypeVersion = "1";

        protected WineCommandBase(string wineId, IDictionary<string, StringValues> headers)
        {
            _headers = headers;
            WineId = wineId;
        }

        public ServiceBusMessage Message
        {
            get
            {
                var message = new ServiceBusMessage(Encoding.ASCII.GetBytes(Body))
                {
                    ContentType = "application/json",
                    CorrelationId = CorrelationId,
                    Subject = MessageLabel,
                    PartitionKey = WineId,
                    ApplicationProperties =
                    {
                        new KeyValuePair<string, object>("AggregateType", $"{AggregateType}"),
                        new KeyValuePair<string, object>("AggregateVersion", $"{AggregateTypeVersion}"),
                        new KeyValuePair<string, object>("EventType", $"{EventType}"),
                        new KeyValuePair<string, object>("EventTypeVersion", $"{EventTypeVersion}")
                    }
                };

                //add the incoming headers to the message
                foreach (var (key, value) in _headers)
                {
                    message.ApplicationProperties.Add(key, value.ToString());
                }

                return message;
            }
        }

        public string WineId { get; }
        public int Version { get; }

        private string CorrelationId
        {
            get
            {
                return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            }
        }

        private string MessageLabel => $"{AggregateType}_{AggregateTypeVersion}_{EventType}_{EventTypeVersion}";

    }
}