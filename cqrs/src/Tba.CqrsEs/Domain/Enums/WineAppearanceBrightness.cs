using System.Runtime.Serialization;

namespace Tba.CqrsEs.Domain.Enums
{
    public enum WineAppearanceBrightness
    {
        [EnumMember(Value = "bright")] Bright,
        [EnumMember(Value = "dull")] Dull
    }
}