using Newtonsoft.Json;

namespace wine_libarary_application.ClientModels
{
    public class AcceptedResponse
    {
        [JsonProperty("eventType")] public string EventType { get; protected set; }

        [JsonProperty("eventTypeVersion")] public string EventTypeVersion { get; }

        public AcceptedResponse(string eventType, string eventTypeVersion)
        {
            EventTypeVersion = eventTypeVersion;
            EventType = eventType;
        }
    }
}