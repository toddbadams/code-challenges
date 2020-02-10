using Microsoft.Build.Framework;

namespace Tba.CqrsEs.Application.Commands
{
    public class UpdateWineBody : CreateWineBody
    {
        [Required]
        public string Id { get; set; }
    }
}