using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Tba.CqrsEs.Application.Commands.RequestBodies
{
    public class UpdateWineTastingAppearanceBody
    {
        [Required, JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("color")] public string? WineColorType { get; }
        [JsonProperty("intensity")] public string? WineAppearanceIntensity { get; }
        [JsonProperty("brightness")] public string? WineAppearanceBrightness { get; }
        [JsonProperty("clarity")] public string? WineAppearanceClarity { get; }
    }
}