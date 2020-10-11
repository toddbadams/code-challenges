using System.Runtime.Serialization;

namespace wine_libarary.Entities
{
    public enum WineType
    {
        [EnumMember(Value="red")] Red,
        [EnumMember(Value="white")] White,
        [EnumMember(Value="sparking")] Sparkling,
        [EnumMember(Value="orange")] Orange,
        [EnumMember(Value="sweet")]Sweet
    }
}