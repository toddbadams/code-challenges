using Newtonsoft.Json;

namespace Tba.CqrsEs.Application.ClientModels
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