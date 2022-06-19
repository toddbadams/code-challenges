using Tba.CqrsEs.Domain.Enums;

namespace Tba.CqrsEs.Domain.ValueTypes
{
    public class Wine
    {
        public Wine(string name, string producer, string country, string region, string subRegion, string appellation, WineType type)
        {
            Name = name;
            Producer = producer;
            Country = country;
            Region = region;
            SubRegion = subRegion;
            Appellation = appellation;
            Type = type;
        }

        public string Name { get; }
        public string Producer { get; }
        public string Country { get; }
        public string Region { get; }
        public string SubRegion { get; }
        public string Appellation { get; }
        public WineType Type { get; }
        public string WineName => $"{Producer} {Name}";
    }
}