using System.Runtime.Serialization;

namespace RefrigeratedTruck.Domain.Enums
{
    public enum ContentsState
    {
        [EnumMember(Value = "full")] full,
        [EnumMember(Value = "melting")] melting,
        [EnumMember(Value = "empty")] empty
    }
}