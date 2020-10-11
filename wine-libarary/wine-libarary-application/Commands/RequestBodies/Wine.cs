using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace wine_libarary_application.Commands.RequestBodies
{
    public class Wine
    {
        [Required, JsonProperty("name")] public string Name { get; set; }

        [Required, JsonProperty("producer")]public string Producer { get; set;  }

        [Required, JsonProperty("location")] public string Location { get; set;  }

        [Required, JsonProperty("type")] public string Type { get; set;  }
    }
}