using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace wine_libarary_application.Commands.RequestBodies
{
    public class SellWineBody 
    {
        [Required, JsonProperty("packQuantity")]public int PackQuantity { get; set; }

        [JsonProperty("price")] public float? Price { get; set; }
    }
}