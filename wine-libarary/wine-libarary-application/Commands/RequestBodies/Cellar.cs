using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace wine_libarary_application.Commands.RequestBodies
{
    public class Cellar
    {
        [Required, JsonProperty("title")]public string Title { get; set; }
        [JsonProperty("accountRef")]public string AccountRef { get; set; }
    }
}