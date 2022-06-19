using System.Runtime.Serialization;

namespace Tba.CqrsEs.Domain.Enums
{
    public enum WineType
    {
        [EnumMember(Value = "red")] Red,
        [EnumMember(Value = "white")] White,
        [EnumMember(Value = "sparking")] Sparkling,
        [EnumMember(Value = "orange")] Orange,
        [EnumMember(Value = "sweet")] Sweet
    }
}