using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace wine_libarary_application.Commands.RequestBodies
{
    public class MoveWineBody 
    {
        [Required, JsonProperty("fromPackQuantity")]public int FromPackQuantity { get; set; }

        [Required, JsonProperty("reason")]public string Reason { get; set; }

        [JsonProperty("dutyPaid")] public float? DutyPaid { get; set; }

        [JsonProperty("vat")] public float? Vat { get; set; }

        [Required, JsonProperty("packQuantity")]public int Quantity { get; set; }

        [Required, JsonProperty("packSize")] public int PackSize { get; set; }
    }
}