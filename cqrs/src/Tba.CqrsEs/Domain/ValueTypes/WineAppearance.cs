using Tba.CqrsEs.Domain.Enums;

namespace Tba.CqrsEs.Domain.ValueTypes
{
    public class WineAppearance
    {
        public WineAppearance(WineColorType? wineColorType, WineAppearanceIntensity? wineAppearanceIntensity, WineAppearanceBrightness? wineAppearanceBrightness, WineAppearanceClarity? wineAppearanceClarity)
        {
            WineColorType = wineColorType;
            WineAppearanceIntensity = wineAppearanceIntensity;
            WineAppearanceBrightness = wineAppearanceBrightness;
            WineAppearanceClarity = wineAppearanceClarity;
        }

        public WineColorType? WineColorType { get; }
        public WineAppearanceIntensity? WineAppearanceIntensity { get; }
        public WineAppearanceBrightness? WineAppearanceBrightness { get; }
        public WineAppearanceClarity? WineAppearanceClarity { get; }
    }
}