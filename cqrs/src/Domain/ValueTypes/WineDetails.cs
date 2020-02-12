using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Tba.CqrsEs.Domain.Enums;

namespace Tba.CqrsEs.Domain.ValueTypes
{
    public class WineDetails
    {
        [Required, JsonProperty("vintage")] public int Vintage { get; set; }

        [Required, JsonProperty("quantity")] public int Quantity { get; set; }

        [Required, JsonProperty("packSize")] public PackSize PackSize { get; set; }

        [Required, JsonProperty("bottleSize")] public BottleSize BottleSize { get; set; }

        [Required, JsonProperty("dutyStatus")] public DutyStatus DutyStatus { get; set; }

        [Required, JsonProperty("unitCost")] public float UnitCost { get; set; }

        [Required, JsonProperty("acquiredOn")] public DateTime AcquiredOn { get; set; }

        [Required, JsonProperty("acquiredFrom")] public string AcquiredFrom { get; set; }

        [Required, JsonProperty("rotationNumber")] public string RotationNumber { get; set; }

        [Required, JsonProperty("note")] public string Note { get; set; }
    }
}