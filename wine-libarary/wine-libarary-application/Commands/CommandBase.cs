using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Primitives;

namespace wine_libarary_application.Commands
{
    public abstract class CommandBase
    {
        private readonly IDictionary<string, StringValues> _headers;

        protected string Body { private get; set; }
        public string EventType { get; set; }
        public string EventTypeVersion { get; set; }

        protected CommandBase( IDictionary<string, StringValues> headers)
        {
            _headers = headers;
        }

        public Message Message
        {
            get
            {
                var message = new Message(Encoding.ASCII.GetBytes(Body))
                {
                    ContentType = "application/json",
                    CorrelationId = CorrelationId,
                    Label = MessageLabel,
                   // PartitionKey = CellarId,
                    UserProperties =
                    {
                        new KeyValuePair<string, object>("EventType", $"{EventType}"),
                        new KeyValuePair<string, object>("EventTypeVersion", $"{EventTypeVersion}")
                    }
                };

                // add the incoming headers to the message
                foreach (var (key, value) in _headers)
                {
                    message.UserProperties.Add(key, value);
                }

                return message;
            }
        }

        private string CorrelationId => Guid.NewGuid().ToString();

        private string MessageLabel => $"{EventType}_{EventTypeVersion}";

    }
}