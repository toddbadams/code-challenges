using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AzureMapsToolkit;
using AzureMapsToolkit.Common;
using Geolocation;
using Microsoft.Azure.Devices.Client;
using RefrigeratedTruck.Application.Configuration;
using RefrigeratedTruck.Domain.Entities;
using RefrigeratedTruck.Domain.Enums;
using RefrigeratedTruck.Domain.ValueObjects;
using RefrigeratedTruck.Presentation;
using Coordinate = AzureMapsToolkit.Common.Coordinate;

namespace RefrigeratedTruck.Domain
{
    public class Truck : IotDevice
    {
        private readonly AzureMapsServices _azureMapsServices;
        public double timeOnCurrentTask = 0;            // Time on current task in seconds.
        public double interval = 60;                    // Simulated time interval in seconds.
        public double tooWarmPeriod = 0;                // Time that contents are too warm in seconds.
        public double tempContents = -2;                // Current temp of contents in degrees C.
        public double baseLat = 47.644702;              // Base position latitude.
        public double baseLon = -122.130137;            // Base position longitude.
        //public double currentLat;                       // Current position latitude.
        //public double currentLon;                       // Current position longitude.
        public double destinationLat;                   // Destination position latitude.
        public double destinationLon;                   // Destination position longitude.

        private double[,] path;                          // Lat/lon steps for the route.
        private double[] timeOnPath;                     // Time in seconds for each section of the route.
        private int truckOnSection;                      // The current path section the truck is on.
        private double truckSectionsCompletedTime;       // The time the truck has spent on previous completed sections.
        public static Random rand;


        public static FanState FanState = FanState.On;                // Cooling FanState state.
        public static ContentsState contents = ContentsState.full;    // Truck contents state.
        public static TruckState TruckState = TruckState.Ready;       // Truck is full and ready to go!
        public static double optimalTemperature = -5;         // Setting - can be changed by the operator from IoT Central.


        const string noEvent = "none";
        static string eventText = noEvent;              // Event text sent to IoT Central.

        public Coordinate CurrentLocation { get; private set; }
        public Coordinate DestinationLocation { get; private set; }

        public TemperatureSensor TemperatureSensor { get; private set; }

        public Truck(AzureMapsServices azureMapsServices, Coordinate startingLocation, IoTDeviceConfig config)
        : base(config)
        {
            _azureMapsServices = azureMapsServices;
            rand = new Random();
            //currentLat = baseLat;
            //currentLon = baseLon;
            CurrentLocation = new Coordinate()
            {
                Longitude = startingLocation.Longitude,
                Latitude = startingLocation.Latitude
            };
        }

        private bool HasArrived()
        {
            //var p = new Path(currentLat, currentLon, destinationLat, destinationLon);
            //return p.Distance < 10;

            return GeoCalculator.GetDistance(CurrentLocation.Latitude, CurrentLocation.Longitude,
                DestinationLocation.Latitude, DestinationLocation.Longitude) < 10;
        }


        void UpdatePosition()
        {
            while ((truckSectionsCompletedTime + timeOnPath[truckOnSection] < timeOnCurrentTask) && (truckOnSection < timeOnPath.Length - 1))
            {
                // Truck has moved onto the next section.
                truckSectionsCompletedTime += timeOnPath[truckOnSection];
                ++truckOnSection;
            }

            // Ensure remainder is 0 to 1, as interval may take count over what is needed.
            var remainderFraction = Math.Min(1, (timeOnCurrentTask - truckSectionsCompletedTime) / timeOnPath[truckOnSection]);

            // The path should be one entry longer than the timeOnPath array.
            // Find how far along the section the truck has moved.
            CurrentLocation.Latitude = path[truckOnSection, 0] + remainderFraction * (path[truckOnSection + 1, 0] - path[truckOnSection, 0]);
            CurrentLocation.Longitude = path[truckOnSection, 1] + remainderFraction * (path[truckOnSection + 1, 1] - path[truckOnSection, 1]);
        }


        void GetRoute(TruckState newTruckState)
        {
            // Set the state to ready, until the new route arrives.
            TruckState = TruckState.Ready;

            var req = new RouteRequestDirections
            {
                Query = $"{ CurrentLocation.Latitude},{ CurrentLocation.Longitude}:{destinationLat},{destinationLon}"
            };
            var directions = _azureMapsServices.GetRouteDirections(req).Result;

            if (directions.Error != null || directions.Result == null)
            {
                // Handle any error.
                ConsoleMessage.Red("Failed to find map route");
            }
            else
            {
                int nPoints = directions.Result.Routes[0].Legs[0].Points.Length;
                ConsoleMessage.Green($"Route found. Number of points = {nPoints}");

                // Clear the path. Add two points for the start point and destination.
                path = new double[nPoints + 2, 2];
                int c = 0;

                // Start with the current location.
                path[c, 0] = CurrentLocation.Latitude;
                path[c, 1] = CurrentLocation.Longitude;
                ++c;

                // Retrieve the route and push the points onto the array.
                for (var n = 0; n < nPoints; n++)
                {
                    var x = directions.Result.Routes[0].Legs[0].Points[n].Latitude;
                    var y = directions.Result.Routes[0].Legs[0].Points[n].Longitude;
                    path[c, 0] = x;
                    path[c, 1] = y;
                    ++c;
                }

                // Finish with the destination.
                path[c, 0] = destinationLat;
                path[c, 1] = destinationLon;

                // Store the path length and time taken, to calculate the average speed.
                var meters = directions.Result.Routes[0].Summary.LengthInMeters;
                var seconds = directions.Result.Routes[0].Summary.TravelTimeInSeconds;
                var pathSpeed = meters / seconds;

                double distanceApartInMeters;
                double timeForOneSection;

                // Clear the time on path array. The path array is 1 less than the points array.
                timeOnPath = new double[nPoints + 1];

                // Calculate how much time is required for each section of the path.
                for (var t = 0; t < nPoints + 1; t++)
                {
                    // Calculate distance between the two path points, in meters.
                    var p = new Path(path[t, 0], path[t, 1], path[t + 1, 0], path[t + 1, 1]);

                    // Calculate the time for each section of the path.
                    timeForOneSection = p.Distance / pathSpeed;
                    timeOnPath[t] = timeForOneSection;
                }
                truckOnSection = 0;
                truckSectionsCompletedTime = 0;
                timeOnCurrentTask = 0;

                // Update the state now the route has arrived. One of: enroute or returning.
                TruckState = newTruckState;
            }
        }

        void UpdateTruck()
        {
            if (contents == ContentsState.empty)
            {
                // Turn the cooling system off, if possible, when the contents are empty.
                if (FanState == FanState.On)
                {
                    FanState = FanState.Off;
                }

                tempContents += -2.9 + DieRoll(6);
            }
            else
            {
                // Contents are full or melting.
                if (FanState != FanState.Failed)
                {
                    if (tempContents < optimalTemperature - 5)
                    {
                        // Turn the cooling system off, as contents are getting too cold.
                        FanState = FanState.Off;
                    }
                    else
                    {
                        if (tempContents > optimalTemperature)
                        {
                            // Temp getting higher, turn cooling system back on.
                            FanState = FanState.On;
                        }
                    }

                    // Randomly fail the cooling system.
                    if (DieRoll(100) < 1)
                    {
                        FanState = FanState.Failed;
                    }
                }

                // Set the contents temperature. Maintaining a cooler temperature if the cooling system is on.
                if (FanState == FanState.On)
                {
                    tempContents += -3 + DieRoll(5);
                }
                else
                {
                    tempContents += -2.9 + DieRoll(6);
                }

                // If the temperature is above a threshold, count the seconds this is occurring, and melt the contents if it goes on too long.
                if (tempContents >= TruckConfig.TooWarmThreshold)
                {
                    // Contents are warming.
                    tooWarmPeriod += interval;

                    if (tooWarmPeriod >= TruckConfig.TooWarmTooLong)
                    {
                        // Contents are melting.
                        contents = ContentsState.melting;
                    }
                }
                else
                {
                    // Contents are cooling.
                    tooWarmPeriod = Math.Max(0, tooWarmPeriod - interval);
                }
            }

            timeOnCurrentTask += interval;

            switch (TruckState)
            {
                case TruckState.Loading:
                    if (timeOnCurrentTask >= TruckConfig.LoadingTime)
                    {
                        // Finished loading.
                        TruckState = TruckState.Ready;
                        contents = ContentsState.full;
                        timeOnCurrentTask = 0;

                        // Turn on the cooling FanState.
                        // If the FanState is in a failed state, assume it has been fixed, as it is at the base.
                        FanState = FanState.On;
                        tempContents = -2;
                    }
                    break;

                case TruckState.Ready:
                    timeOnCurrentTask = 0;
                    break;

                case TruckState.Delivering:
                    if (timeOnCurrentTask >= TruckConfig.DeliverTime)
                    {
                        // Finished delivering.
                        contents = ContentsState.empty;
                        ReturnToBase();
                    }
                    break;

                case TruckState.Returning:

                    // Update the truck position.
                    UpdatePosition();

                    // Check to see if the truck has arrived back at base.
                    if (HasArrived())
                    {
                        switch (contents)
                        {
                            case ContentsState.empty:
                                TruckState = TruckState.Loading;
                                break;

                            case ContentsState.full:
                                TruckState = TruckState.Ready;
                                break;

                            case ContentsState.melting:
                                TruckState = TruckState.Dumping;
                                break;
                        }

                        timeOnCurrentTask = 0;
                    }
                    break;

                case TruckState.Enroute:

                    // Move the truck.
                    UpdatePosition();

                    // Check to see if the truck has arrived at the customer.
                    if (HasArrived())
                    {
                        TruckState = TruckState.Delivering;
                        timeOnCurrentTask = 0;
                    }
                    break;

                case TruckState.Dumping:
                    if (timeOnCurrentTask >= TruckConfig.DumpingTime)
                    {
                        // Finished dumping.
                        TruckState = TruckState.Loading;
                        contents = ContentsState.empty;
                        timeOnCurrentTask = 0;
                    }
                    break;
            }
        }

        private static double DieRoll(double max)
        {
            return rand.NextDouble() * max;
        }


        public void ReturnToBase()
        {
            destinationLat = baseLat;
            destinationLon = baseLon;

            // Find route from current position to base, storing route.
            GetRoute(TruckState.Returning);
        }



        public async void SendTruckTelemetryAsync(CancellationToken token, DeviceClient s_deviceClient)
        {
            while (true)
            {
                UpdateTruck();

                // Create the telemetry JSON message.
                var telemetryDataPoint = new
                {
                    ContentsTemperature = Math.Round(tempContents, 2),
                    TruckState = TruckState.ToString(),
                    CoolingSystemState = FanState.ToString(),
                    ContentsState = contents.ToString(),
                    Location = new { lon = CurrentLocation.Longitude, lat = CurrentLocation.Latitude },
                    Event = eventText,
                };
                var telemetryMessageString = JsonSerializer.Serialize(telemetryDataPoint);
                var telemetryMessage = new Message(Encoding.ASCII.GetBytes(telemetryMessageString));

                // Clear the events, as the message has been sent.
                eventText = noEvent;

                Console.WriteLine($"\nTelemetry data: {telemetryMessageString}");

                // Bail if requested.
                token.ThrowIfCancellationRequested();

                // Send the telemetry message.
                await s_deviceClient.SendEventAsync(telemetryMessage);
                ConsoleMessage.Green($"Telemetry sent {DateTime.Now.ToShortTimeString()}");

                await Task.Delay(TruckConfig.IntervalInMilliseconds);
            }
        }

        public Task<MethodResponse> CmdRecall(MethodRequest methodRequest, object userContext)
        {
            switch (Truck.TruckState)
            {
                case TruckState.Ready:
                case TruckState.Loading:
                case TruckState.Dumping:
                    eventText = "Already at base";
                    break;

                case TruckState.Returning:
                    eventText = "Already returning";
                    break;

                case TruckState.Delivering:
                    eventText = "Unable to recall - " + Truck.TruckState;
                    break;

                case TruckState.Enroute:
                    ReturnToBase();
                    break;
            }

            // Acknowledge the command.
            if (eventText == noEvent)
            {
                // Acknowledge the direct method call with a 200 success message.
                string result = "{\"result\":\"Executed direct method: " + methodRequest.Name + "\"}";
                return Task.FromResult(new MethodResponse(Encoding.UTF8.GetBytes(result), 200));
            }
            else
            {
                // Acknowledge the direct method call with a 400 error message.
                string result = "{\"result\":\"Invalid call\"}";
                return Task.FromResult(new MethodResponse(Encoding.UTF8.GetBytes(result), 400));
            }
        }


        public Task<MethodResponse> CmdGoToCustomer(MethodRequest methodRequest, object userContext)
        {
            try
            {
                // Pick up variables from the request payload, with the name specified in IoT Central.
                var payloadString = Encoding.UTF8.GetString(methodRequest.Data);
                int customerNumber = Int32.Parse(payloadString);

                // Check for a valid key and customer ID.
                if (customerNumber >= 0 && customerNumber < Locations.Customers.Length)
                {
                    switch (Truck.TruckState)
                    {
                        case TruckState.Dumping:
                        case TruckState.Loading:
                        case TruckState.Delivering:
                            eventText = "Unable to act - " + Truck.TruckState;
                            break;

                        case TruckState.Ready:
                        case TruckState.Enroute:
                        case TruckState.Returning:
                            if (Truck.contents == ContentsState.empty)
                            {
                                eventText = "Unable to act - empty";
                            }
                            else
                            {
                                // Set event only when all is good.
                                eventText = "New customer: " + customerNumber.ToString();

                                destinationLat = Locations.Customers[customerNumber, 0];
                                destinationLon = Locations.Customers[customerNumber, 1];

                                // Find route from current position to destination, storing route.
                                GetRoute(TruckState.Enroute);
                            }
                            break;
                    }

                    // Acknowledge the direct method call with a 200 success message.
                    string result = "{\"result\":\"Executed direct method: " + methodRequest.Name + "\"}";
                    return Task.FromResult(new MethodResponse(Encoding.UTF8.GetBytes(result), 200));
                }
                else
                {
                    eventText = $"Invalid customer: {customerNumber}";

                    // Acknowledge the direct method call with a 400 error message.
                    string result = "{\"result\":\"Invalid customer\"}";
                    return Task.FromResult(new MethodResponse(Encoding.UTF8.GetBytes(result), 400));
                }
            }
            catch
            {
                // Acknowledge the direct method call with a 400 error message.
                string result = "{\"result\":\"Invalid call\"}";
                return Task.FromResult(new MethodResponse(Encoding.UTF8.GetBytes(result), 400));
            }
        }

    }
}