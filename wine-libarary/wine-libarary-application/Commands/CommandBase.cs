using System;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace wine_libarary_application.Commands
{
    public abstract class CommandBase
    {
        private readonly IDictionary<string, StringValues> _headers;

        protected string Body { private get; set; }
        protected string EventType { private get; set; }
        protected string EventTypeVersion { private get; set; }

        private const string AggregateType = "Wine";
        private const string AggregateTypeVersion = "1";

        protected CommandBase(string wineId, IDictionary<string, StringValues> headers)
        {
            _headers = headers;
            WineId = wineId;
        }

        //public Message Message
        //{
        //    get
        //    {
        //        var message = new Message(Encoding.ASCII.GetBytes(Body))
        //        {
        //            ContentType = "application/json",
        //            CorrelationId = CorrelationId,
        //            Label = MessageLabel,
        //            PartitionKey = WineId,
        //            UserProperties =
        //            {
        //                new KeyValuePair<string, object>("AggregateType", $"{AggregateType}"),
        //                new KeyValuePair<string, object>("AggregateVersion", $"{AggregateTypeVersion}"),
        //                new KeyValuePair<string, object>("EventType", $"{EventType}"),
        //                new KeyValuePair<string, object>("EventTypeVersion", $"{EventTypeVersion}")
        //            }
        //        };

        //        // add the incoming headers to the message
        //        foreach (var (key, value) in _headers)
        //        {
        //            message.UserProperties.Add(key, value);
        //        }

        //        return message;
        //    }
        //}

        public string WineId { get; }
        public int Version { get; }

        private string CorrelationId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private string MessageLabel => $"{AggregateType}_{AggregateTypeVersion}_{EventType}_{EventTypeVersion}";

    }
}