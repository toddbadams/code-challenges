using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using Simulator.Configurations;

namespace Simulator
{
    public class DeviceSimulation : IDeviceSimulation
    {
        private const double Percentage = 5; // variation in next random value
        private static readonly Random Rand = new Random();
        private readonly Settings _settings;
        private static DeviceClient _deviceClient;
        private double _currentTemperature;
        private double _currentHumidity;

        public DeviceSimulation(Settings settings)
        {
            _settings = settings;
            _deviceClient = DeviceClient.CreateFromConnectionString(_settings.ConnectionString, TransportType.Mqtt);
            _currentHumidity = _settings.Humidity.Initial;
            _currentTemperature = _settings.Temperature.Initial;
        }

        /// <summary>
        /// Send telemetry data to Azure IOT Hub
        /// </summary>
        /// <returns></returns>
        public async Task SendMessagesAsync()
        {
            for (var i=0; i<_settings.TelemetryCount; i++)
            {
                _currentTemperature = GenerateSensorReading(_currentTemperature, _settings.Temperature.Min, _settings.Temperature.Max);
                _currentHumidity = GenerateSensorReading(_currentHumidity, _settings.Humidity.Min, _settings.Humidity.Max);
                var truckMessage = CreateMessage(CreateJson(_currentTemperature, _currentHumidity));
                await _deviceClient.SendEventAsync(truckMessage);
                await Task.Delay(_settings.IntervalMilliseconds);
            }
        }

        /// <summary>
        /// generate a new value based on the previous supplied value
        /// The new value will be calculated to be within the threshold specified by the
        /// "percentage" variable from the original number.
        /// The value will also always be within the the specified "min" and "max" values.
        /// </summary>
        private static double GenerateSensorReading(double currentValue, double min, double max)
        {
            var value = currentValue * (1 + ((Percentage / 100) * (2 * Rand.NextDouble() - 1)));

            value = Math.Max(value, min);
            value = Math.Min(value, max);

            return value;
        }

        /// <summary>
        /// convert current temperature and humidity to telemetry JSON
        /// </summary>
        private static string CreateJson(double temperature, double humidity) =>
            JsonConvert.SerializeObject(new { temperature, humidity });

        /// <summary>
        /// Generate Telemetry message containing JSON data for the specified values
        /// </summary>
        private static Message CreateMessage(string messageString) =>
            new Message(Encoding.ASCII.GetBytes(messageString))
            {
                ContentType = "application/json",
                ContentEncoding = "UTF-8"
            };
    }
}