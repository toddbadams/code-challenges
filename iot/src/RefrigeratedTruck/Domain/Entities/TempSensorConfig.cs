namespace RefrigeratedTruck.Domain
{
    public readonly struct TempSensorConfig
    {
        public double TempSensorMin { get; }
        public double TempSensorCurrent { get; }
        public double TempSensorMax { get; }

        public TempSensorConfig(double tempSensorMax, double tempSensorMin, double tempSensorCurrent)
        {
            TempSensorMin = tempSensorMin;
            TempSensorCurrent = tempSensorCurrent;
            TempSensorMax = tempSensorMax;
        }
    }
}