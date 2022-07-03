using Newtonsoft.Json;

namespace Tba.CqrsEs.Application.Commands.RequestBodies
{
    public class UpdateWineTastingNoseBody
    {
        [JsonProperty("intensity")] public string Intensity { get; }
        [JsonProperty("aromas")] public string[] Aromas { get; }
    }
}