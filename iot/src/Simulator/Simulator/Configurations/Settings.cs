namespace Simulator.Configurations

{
    public readonly struct Settings
    {
        public SettingRange Temperature { get; }
        public SettingRange Humidity { get; }
        public string ConnectionString { get; }
        public int TelemetryCount { get; }
        public int IntervalMilliseconds { get; }

        public Settings(SettingRange temperature, SettingRange humidity, 
            string connectionString, int telemetryCount, int intervalMilliseconds)
        {
            Temperature = temperature;
            Humidity = humidity;
            ConnectionString = connectionString;
            TelemetryCount = telemetryCount;
            IntervalMilliseconds = intervalMilliseconds;
        }
    }
}