using System.Runtime.Serialization;

namespace Tba.CqrsEs.Domain.Enums
{
    public enum DutyStatus
    {
        [EnumMember(Value="DP")] DutyPaid,
        [EnumMember(Value="IB")] InBond
    }
}