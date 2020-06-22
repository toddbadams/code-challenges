using System;
using System.Collections.Generic;
using System.Text;
using Geolocation;

namespace RefrigeratedTruck.Domain.Entities
{
    public class Customer
    {
        public string Id { get; }
        private Coordinate Location { get; }

        public Customer(string id, double lat, double lon)
        {
            Id = id;
            Location =  new Coordinate(lat, lon);
        }

        public double DistanceTo(Coordinate to) =>
            GeoCalculator.GetDistance(Location.Latitude, Location.Longitude, to.Latitude,
                to.Longitude);
    }
}
