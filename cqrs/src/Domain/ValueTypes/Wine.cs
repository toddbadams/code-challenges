using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Tba.CqrsEs.Domain.Enums;

namespace Tba.CqrsEs.Domain.ValueTypes
{
    public class Wine
    {
        [Required, JsonProperty("name")] public string Name { get; set; }

        [Required, JsonProperty("producer")] public string Producer { get; set; }

        [Required, JsonProperty("country")] public string Country { get; set; }

        [Required, JsonProperty("region")] public string Region { get; set; }

        [JsonProperty("subRegion")] public string SubRegion { get; set; }

        [JsonProperty("appellation")] public string Appellation { get; set; }

        [Required, JsonProperty("type")] public WineType Type { get; set; }
    }
}