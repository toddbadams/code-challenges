using Newtonsoft.Json;

namespace Tba.CqrsEs.Application.Commands.RequestBodies
{
    public class UpdateWineTastingPalateBody
    {
        [JsonProperty("sweetness")] public string Sweetness { get; }
        [JsonProperty("acidity")] public string Acitidy { get; }
        [JsonProperty("tanninLevel")] public string TanninLevel { get; }
        [JsonProperty("tanninNature")] public string TanninNature { get; }
        [JsonProperty("alcohol")] public string Alcohol { get; }
        [JsonProperty("body")] public string Body { get; }
        [JsonProperty("intensity")] public string Intensity { get; }
        [JsonProperty("flavors")] public string[] Flavors { get; }
        [JsonProperty("texture")] public string Texture { get; }
        [JsonProperty("petillance")] public string Petillance { get; }
        [JsonProperty("finish")] public string Finish { get; }
    }
}