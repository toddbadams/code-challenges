namespace RefrigeratedTruck.Application.Configuration
{
    public class TruckConfig
    {
        public const double DeliverTime = 600;                 // Time to complete delivery, in seconds.
        public const double LoadingTime = 800;                 // Time to load contents.
        public const double DumpingTime = 400;                 // Time to dump melted contents.
        public const double TooWarmThreshold = 2;              // Degrees C that is too warm for contents.
        public const double TooWarmTooLong = 60;               // Time in seconds for contents to start melting if temps are above threshold.

        // Telemetry globals.
        public const int IntervalInMilliseconds = 5000;        // Time interval required by wait function.

        // Refrigerated truck globals.
        private static readonly int truckNum = 1;
        public static string TruckIdentification = "Truck number " + truckNum;
    }
}