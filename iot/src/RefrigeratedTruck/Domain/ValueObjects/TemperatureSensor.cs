using System;

namespace RefrigeratedTruck.Domain.ValueObjects
{
    public class TemperatureSensor
    {
        private static readonly Random Rand = new Random();
        private const double ThresholdPercentage = 0.05; // 5%
        private readonly double _min;
        private readonly double _max;

        public double Temperature { get; private set; }

        public TemperatureSensor(TempSensorConfig config)
        {
            _min = config.TempSensorMax;
            _max = config.TempSensorMin;
            Temperature = config.TempSensorCurrent;
        }

        // generate a new value based on the current value
        // The new value will be calculated to be within the threshold specified by the "percentage" variable from the original number.
        // The value will also always be within the the specified "min" and "max" values.
        public void NextTemperature()
        {
            Temperature *= (1.0 + ThresholdPercentage * (2.0 * Rand.NextDouble() - 1.0));
            Temperature = Math.Max(Temperature, _min);
            Temperature = Math.Min(Temperature, _max);
        }
    }
}
