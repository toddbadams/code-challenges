using Newtonsoft.Json;

namespace wine_libarary_application.ClientModels
{
    public class AcceptedResponse
    {
        [JsonProperty("id")] public string Id { get; protected set; }

        [JsonProperty("version")] public int Version { get; }

        public AcceptedResponse(string id, int version)
        {
            Version = version;
            Id = id;
        }

    }
}