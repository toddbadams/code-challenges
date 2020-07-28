using System.Runtime.Serialization;

namespace wine_libarary
{
    public enum BottleSize
    {
        [EnumMember(Value="37.5cl")] Half,
        [EnumMember(Value="75cl")] Full,
        [EnumMember(Value="150cl")] Magnum
    }
}