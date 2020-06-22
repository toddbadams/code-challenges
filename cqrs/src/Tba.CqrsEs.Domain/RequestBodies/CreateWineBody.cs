using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Tba.CqrsEs.Domain.ValueTypes;

namespace Tba.CqrsEs.Application.Commands.RequestBodies
{
    public class CreateWineBody
    {
        [Required, JsonProperty("wine")] public Wine Wine { get; set; }

        [Required, JsonProperty("details")] public WineDetails Details { get; set; }
    }
}
