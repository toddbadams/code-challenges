using Microsoft.Build.Framework;

namespace Tba.CqrsEs.Application.Commands
{
    public class CreateWineBody
    {
        [Required]
        public int Vintage { get; set; }

        [Required]
        public string Name { get; set; }

        public string Region { get; set; }
    }
}
