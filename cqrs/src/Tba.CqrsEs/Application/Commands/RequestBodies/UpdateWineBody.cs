using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Tba.CqrsEs.Domain.ValueTypes;

namespace Tba.CqrsEs.Application.Commands.RequestBodies
{
    public class UpdateWineBody 
    {
        [Required, JsonProperty("id")] public string Id { get; set; }

        [Required, JsonProperty("details")] public WineDetails Details { get; set; }

        [Required, JsonProperty("action")] public UpdateWineActions Action { get; set; }
    }
}