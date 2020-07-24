using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Tba.CqrsEs.Domain.ValueTypes;

namespace Tba.CqrsEs.Application.Commands.RequestBodies
{
    public class CreateWineBody
    {
        [Required, JsonProperty("wine")] public WineBody Wine { get; set; }

        [Required, JsonProperty("details")] public WineDetailsBody Details { get; set; }
    }
}
