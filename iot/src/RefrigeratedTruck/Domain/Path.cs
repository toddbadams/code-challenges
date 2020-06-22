using System;
using System.Collections.Generic;
using System.Text;

namespace RefrigeratedTruck.Domain
{
   public class Path
    {
        private readonly double _lat1;
        private readonly double _lon1;
        private readonly double _lat2;
        private readonly double _lon2;

        public double Distance { get; }

        public Path(double lat1, double lon1, double lat2, double lon2)
        {
            _lat1 = lat1;
            _lon1 = lon1;
            _lat2 = lat2;
            _lon2 = lon2;
            Distance = DistanceInMeters(lat1, lon1, lat2, lon2);
        }

        static double DistanceInMeters(double lat1, double lon1, double lat2, double lon2)
        {
            var dlon = Degrees2Radians(lon2 - lon1);
            var dlat = Degrees2Radians(lat2 - lat1);

            var a = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2)) + Math.Cos(Degrees2Radians(lat1)) * Math.Cos(Degrees2Radians(lat2)) * (Math.Sin(dlon / 2) * Math.Sin(dlon / 2));
            var angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var meters = angle * 6371000;
            return meters;
        }

        private static double Degrees2Radians(double deg)
        {
            return deg * Math.PI / 180;
        }
    }
}
