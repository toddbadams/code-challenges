using Newtonsoft.Json;

namespace wine_libarary_application.ClientModels
{
    public class ErrorResponse 
    {
        [JsonProperty("message")] public string Message { get; }

        public ErrorResponse(string message) 
        {
            Message = message;
        }
    }
}
