using System;
using System.Collections.Generic;
using System.Text;
using AzureMapsToolkit;
using AzureMapsToolkit.Common;
using Geolocation;
using RefrigeratedTruck.Domain.Enums;
using RefrigeratedTruck.Presentation;
using Coordinate = AzureMapsToolkit.Common.Coordinate;

namespace RefrigeratedTruck.Domain.ValueObjects
{
    public readonly struct GpsSensorConfig
    {
        public Coordinate Location { get; }

        public GpsSensorConfig(double lat, double lon)
        {
            Location = new Coordinate { Longitude = lon, Latitude = lat };
        }
    }

    public readonly struct Route
    {
        public IEnumerable<RouteSection> Sections { get; }

        public Route(IEnumerable<RouteSection> sections)
        {
            Sections = sections;
        }
    }

    public readonly struct RouteSection
    {
        public Coordinate From { get; }
        public Coordinate To { get; }
        public TimeSpan TimeSpan { get; }

        public RouteSection(Coordinate from, Coordinate to, TimeSpan timeSpan)
        {
            From = @from;
            To = to;
            TimeSpan = timeSpan;
        }
    }

    public class RoutePlanner
    {
        private readonly AzureMapsServices _azureMapsServices;

        public RoutePlanner(AzureMapsServices azureMapsServices)
        {
            _azureMapsServices = azureMapsServices;
        }

        public Route Calculate(Coordinate from, Coordinate to)
        {
            var directions = Directions(from, to);
            var nPoints = directions.Legs[0].Points.Length;

            var routeSections = new List<RouteSection>();
            _path = new double[nPoints + 2, 2];
            var c = 0;

            // Start with the current location.
            _path[c, 0] = Location.Latitude;
            _path[c, 1] = Location.Longitude;
            ++c;

            routeSections.Add(new RouteSection());

            // Retrieve the route and push the points onto the array.
            for (var n = 0; n < nPoints; n++)
            {
                var x = directions.Legs[0].Points[n].Latitude;
                var y = directions.Legs[0].Points[n].Longitude;
                _path[c, 0] = x;
                _path[c, 1] = y;
                ++c;
            }

            // Finish with the destination.
            _path[c, 0] = Destination.Latitude;
            _path[c, 1] = Destination.Longitude;

            // Store the path length and time taken, to calculate the average speed.
            var meters = directions.Summary.LengthInMeters;
            var seconds = directions.Summary.TravelTimeInSeconds;
            var pathSpeed = meters / seconds;

            // Clear the time on path array. The path array is 1 less than the points array.
            _timeOnPath = new double[nPoints + 1];

            // Calculate how much time is required for each section of the path.
            for (var t = 0; t < nPoints + 1; t++)
            {
                // Calculate distance between the two path points, in meters.
                var p = new Path(_path[t, 0], _path[t, 1], _path[t + 1, 0], _path[t + 1, 1]);

                // Calculate the time for each section of the path.
                var timeForOneSection = p.Distance / pathSpeed;
                _timeOnPath[t] = timeForOneSection;
            }
        }


        private RouteDirectionsResult Directions(Coordinate from, Coordinate to)
        {
            var req = new RouteRequestDirections
            {
                Query = $"{from.Latitude},{from.Longitude}:{to.Latitude},{to.Longitude}"
            };
            var directions = _azureMapsServices.GetRouteDirections(req).Result;

            if (directions.Error != null || directions.Result == null)
            {
                throw new ApplicationException("Failed to find map route");
            }

            return directions.Result.Routes[0];
        }
    }

    public class GpsSensor
    {
        // determines next destination path
        private readonly AzureMapsServices _azureMapsServices;
        private const int LocationTolerance = 10;
        private double _timeOnCurrentTask = 0;            // Time on current task in seconds.
        private double _truckSectionsCompletedTime;       // The time spent on previous completed sections.
        private double[,] _path;                          // Lat/lon steps for the route.
        private double[] _timeOnPath;                     // Time in seconds for each section of the route.
        private int _truckOnSection;                      // The current path section the truck is on.
        private double truckSectionsCompletedTime;       // The time the truck has spent on previous completed sections.

        public Coordinate Location { get; }
        public Coordinate Destination { get; private set; }

        public GpsSensor(GpsSensorConfig config, AzureMapsServices azureMapsServices)
        {
            _azureMapsServices = azureMapsServices;
            Location = config.Location;
        }

        public void CalculateRoute(Coordinate location)
        {
            Destination = location;

            var directions = Directions();
            var nPoints = directions.Legs[0].Points.Length;

            // Clear the current path. Add two points for the start point and destination.
            _path = new double[nPoints + 2, 2];
            var c = 0;

            // Start with the current location.
            _path[c, 0] = Location.Latitude;
            _path[c, 1] = Location.Longitude;
            ++c;

            // Retrieve the route and push the points onto the array.
            for (var n = 0; n < nPoints; n++)
            {
                var x = directions.Legs[0].Points[n].Latitude;
                var y = directions.Legs[0].Points[n].Longitude;
                _path[c, 0] = x;
                _path[c, 1] = y;
                ++c;
            }

            // Finish with the destination.
            _path[c, 0] = Destination.Latitude;
            _path[c, 1] = Destination.Longitude;

            // Store the path length and time taken, to calculate the average speed.
            var meters = directions.Summary.LengthInMeters;
            var seconds = directions.Summary.TravelTimeInSeconds;
            var pathSpeed = meters / seconds;

            // Clear the time on path array. The path array is 1 less than the points array.
            _timeOnPath = new double[nPoints + 1];

            // Calculate how much time is required for each section of the path.
            for (var t = 0; t < nPoints + 1; t++)
            {
                // Calculate distance between the two path points, in meters.
                var p = new Path(_path[t, 0], _path[t, 1], _path[t + 1, 0], _path[t + 1, 1]);

                // Calculate the time for each section of the path.
                var timeForOneSection = p.Distance / pathSpeed;
                _timeOnPath[t] = timeForOneSection;
            }
            _truckOnSection = 0;
            truckSectionsCompletedTime = 0;
            _timeOnCurrentTask = 0;
        }

        private RouteDirectionsResult Directions()
        {
            var req = new RouteRequestDirections
            {
                Query = $"{Location.Latitude},{Location.Longitude}:{Destination.Latitude},{Destination.Longitude}"
            };
            var directions = _azureMapsServices.GetRouteDirections(req).Result;

            if (directions.Error != null || directions.Result == null)
            {
                throw new ApplicationException("Failed to find map route");
            }

            return directions.Result.Routes[0];
        }

        public void UpdatePosition()
        {
            while ((_truckSectionsCompletedTime + _timeOnPath[_truckOnSection] < _timeOnCurrentTask) && (_truckOnSection < _timeOnPath.Length - 1))
            {
                // moved onto the next section.
                _truckSectionsCompletedTime += _timeOnPath[_truckOnSection];
                ++_truckOnSection;
            }

            // Ensure remainder is 0 to 1, as interval may take count over what is needed.
            var remainderFraction = Math.Min(1, (_timeOnCurrentTask - _truckSectionsCompletedTime) / _timeOnPath[_truckOnSection]);

            // The path should be one entry longer than the timeOnPath array.
            // Find how far along the section the truck has moved.
            Location.Latitude = _path[_truckOnSection, 0] + remainderFraction * (_path[_truckOnSection + 1, 0] - _path[_truckOnSection, 0]);
            Location.Longitude = _path[_truckOnSection, 1] + remainderFraction * (_path[_truckOnSection + 1, 1] - _path[_truckOnSection, 1]);
        }


        private bool HasArrived =>
            GeoCalculator.GetDistance(Location.Latitude, Location.Longitude,
                Destination.Latitude, Destination.Longitude) < LocationTolerance;
    }
}
