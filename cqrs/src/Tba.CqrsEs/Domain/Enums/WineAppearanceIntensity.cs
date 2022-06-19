using System.Runtime.Serialization;

namespace Tba.CqrsEs.Domain.Enums
{
    public enum WineAppearanceIntensity
    {
        [EnumMember(Value = "pale")] Pale,
        [EnumMember(Value = "medium")] Medium,
        [EnumMember(Value = "deep")] Deep
    }
}