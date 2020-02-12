using Newtonsoft.Json;

namespace Tba.CqrsEs.Application.ClientModels
{
    public class ErrorResponse : AcceptedResponse
    {
        [JsonProperty("message")] public string Message { get; }

        public ErrorResponse(string orderId, int version, string message) : base(orderId, version)
        {
            Message = message;
        }
    }
}
