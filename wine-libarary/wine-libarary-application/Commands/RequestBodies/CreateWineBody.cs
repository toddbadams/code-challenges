using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace wine_libarary_application.Commands.RequestBodies
{
    public class CreateWineBody
    {
        [Required, JsonProperty("wine")] public WineBody Wine { get; set; }

        [Required, JsonProperty("details")] public WineDetailsBody Details { get; set; }
    }
}
