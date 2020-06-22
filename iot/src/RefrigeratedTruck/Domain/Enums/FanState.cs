using System.Runtime.Serialization;

namespace RefrigeratedTruck.Domain.Enums
{
    public enum FanState
    {
        [EnumMember(Value = "on")] On,
        [EnumMember(Value = "off")] Off,
        [EnumMember(Value = "failed")] Failed
    }
}