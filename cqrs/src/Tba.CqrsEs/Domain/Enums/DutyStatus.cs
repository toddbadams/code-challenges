using System.Runtime.Serialization;

namespace Tba.CqrsEs.Domain.Enums
{
    public enum DutyStatus
    {
        [EnumMember(Value="1x75")] One75,
        [EnumMember(Value="6x75")] Six75,
        [EnumMember(Value="12x75")] Twelve75,
        [EnumMember(Value="1x150")] One150,
        [EnumMember(Value="3x150")] Three150,
        [EnumMember(Value="6x150")] Six150,
    }
}