using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Tba.CqrsEs.Application.Commands.RequestBodies
{
    public class CreateWineTastingBody
    {
        [Required, JsonProperty("lat")] public double Lat { get; set; }
        [Required, JsonProperty("lon")] public double Lon { get; set; }
        [Required, JsonProperty("time")] public double Time { get; set; }
    }
}
