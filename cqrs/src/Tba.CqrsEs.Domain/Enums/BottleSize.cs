using System.Runtime.Serialization;

namespace Tba.CqrsEs.Domain.Enums
{
    public enum BottleSize
    {
        [EnumMember(Value="37.5cl")] Half,
        [EnumMember(Value="75cl")] Full,
        [EnumMember(Value="150cl")] Magnum
    }
}