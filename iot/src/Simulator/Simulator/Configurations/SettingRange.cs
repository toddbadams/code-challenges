namespace Simulator.Configurations
{
    public readonly struct SettingRange
    {
        public double Min { get; }
        public double Max { get; }
        public double Initial { get; }

        public SettingRange(double min, double max, double initial)
        {
            Min = min;
            Max = max;
            Initial = initial;
        }
    }
}