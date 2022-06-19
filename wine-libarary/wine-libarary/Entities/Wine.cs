using System;

namespace wine_libarary.Entities
{
    public class Wine
    {
        public Wine(int vintage, string name, string region, string producer, string country, string subRegion, string appellation, WineType type) {
            Vintage = vintage;
            Name = name;
            Region = region;
            Producer = producer;
            Country = country;
            SubRegion = subRegion;
            Appellation = appellation;
            Type = type;
        }

        public int Vintage { get; }

        public string Name { get;  }

        public string Region { get;  }

        public string Producer { get; }

        public string Country { get; }

        public string SubRegion { get;  }

        public string Appellation { get; }

        public WineType Type { get;  }

        
        public string WineName => $"{Producer} {Name}";

       
    }

    public class WineDetails
    {
        public int Vintage { get; set; }

        public int Quantity { get; set; }

        public PackSize PackSize { get; set; }

        public BottleSize BottleSize { get; set; }

        public DutyStatus DutyStatus { get; set; }

        public float UnitCost { get; set; }

        public DateTime AcquiredOn { get; set; }

        public string AcquiredFrom { get; set; }

        public string RotationNumber { get; set; }

        public string Note { get; set; }


    }
}
