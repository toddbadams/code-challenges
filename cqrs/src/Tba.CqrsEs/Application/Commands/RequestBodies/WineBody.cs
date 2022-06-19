using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Tba.CqrsEs.Domain.Enums;

namespace Tba.CqrsEs.Application.Commands.RequestBodies
{
    public class WineBody
    {
        [Required, JsonProperty("wine")] public string Name { get; set; }

        [Required, JsonProperty("producer")] public string Producer { get; set; }

        [Required, JsonProperty("country")] public string Country { get; set; }

        [JsonProperty("region")] public string Region { get; set; }

        [JsonProperty("subRegion")] public string SubRegion { get; set; }

        [Required, JsonProperty("appellation")] public string Appellation { get; set; }

        [Required, JsonProperty("type")] public WineType Type { get; set; }
    }
}