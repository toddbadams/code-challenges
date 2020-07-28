using System.Runtime.Serialization;

namespace wine_libarary
{
    public enum DutyStatus
    {
        [EnumMember(Value="DP")] DutyPaid,
        [EnumMember(Value="IB")] InBond
    }
}