using System.Runtime.Serialization;

namespace RefrigeratedTruck.Domain.Enums
{
    public enum TruckState
    {
        [EnumMember(Value = "ready")] Ready,
        [EnumMember(Value = "enroute")] Enroute,
        [EnumMember(Value = "delivering")] Delivering,
        [EnumMember(Value = "returning")] Returning,
        [EnumMember(Value = "loading")] Loading,
        [EnumMember(Value = "dumping")] Dumping
    };
}