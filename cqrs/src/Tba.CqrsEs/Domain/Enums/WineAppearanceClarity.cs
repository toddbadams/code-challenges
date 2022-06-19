using System.Runtime.Serialization;

namespace Tba.CqrsEs.Domain.Enums
{
    public enum WineAppearanceClarity
    {
        [EnumMember(Value = "clear")] Clear,
        [EnumMember(Value = "cloudy")] Cloudy
    }
}