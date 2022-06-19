using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using Tba.CqrsEs.Domain.Enums;

namespace Tba.CqrsEs.Application.Commands.RequestBodies
{
    public class WineDetailsBody
    {
        [Required, JsonProperty("vintage")] public int Vintage { get; set; }

        [Required, JsonProperty("quantity")] public int Quantity { get; set; }

        [Required, JsonProperty("packSize")] public PackSize PackSize { get; set; }

        [Required, JsonProperty("bottleSize")] public BottleSize BottleSize { get; set; }

        [Required, JsonProperty("dutyStatus")] public DutyStatus DutyStatus { get; set; }

        [JsonProperty("unitCost")] public float? UnitCost { get; set; }

        [JsonProperty("acquiredOn")] public DateTime? AcquiredOn { get; set; }

        [JsonProperty("acquiredFrom")] public string AcquiredFrom { get; set; }
    }
}