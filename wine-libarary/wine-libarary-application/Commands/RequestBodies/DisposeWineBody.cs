using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace wine_libarary_application.Commands.RequestBodies
{
    public class DisposeWineBody 
    {
        [Required, JsonProperty("packQuantity")]public int PackQuantity { get; set; }

        [Required, JsonProperty("reason")]public string Reason { get; set; }
    }
}