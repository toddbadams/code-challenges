using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace wine_libarary_application.Commands.RequestBodies
{
    public class WineEntry
    {
        [Required, JsonProperty("vintage")]public int Vintage { get; set; }

        [Required, JsonProperty("quantity")]public int Quantity { get; set; }

        [Required, JsonProperty("packSize")] public int PackSize { get; set; }

        [Required, JsonProperty("bottleSize")] public int BottleSize { get; set; }

        [Required, JsonProperty("dutyStatus")]public string DutyStatus { get; set; }

        [Required, JsonProperty("cellar")]public Cellar Cellar { get; set; }

        [Required, JsonProperty("wine")]public Wine Wine { get; set; }

        [JsonProperty("unitCost")] public float? UnitCost { get; set; }

        [JsonProperty("acquiredOn")] public DateTime? AcquiredOn { get; set; }

        [JsonProperty("acquiredFrom")] public string AcquiredFrom { get; set; }
    }
}