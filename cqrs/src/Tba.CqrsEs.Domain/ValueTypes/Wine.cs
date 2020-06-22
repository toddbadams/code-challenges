using System.ComponentModel.DataAnnotations;
using Tba.CqrsEs.Domain.Enums;

namespace Tba.CqrsEs.Domain.ValueTypes
{
    public class Wine
    {
        public string Name { get; set; }

        public string Producer { get; set; }

        public string WineName => $"{Producer} {Name}";

        public string Country { get; set; }

        public string Region { get; set; }

        public string SubRegion { get; set; }

        public string Appellation { get; set; }

        public WineType Type { get; set; }
    }
}