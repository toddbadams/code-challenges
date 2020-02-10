using System.ComponentModel.DataAnnotations;

namespace Tba.CqrsEs.Application.Commands
{
    public class UpdateWineBody : CreateWineBody
    {
        [Required]
        public string Id { get; set; }
    }
}