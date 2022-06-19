using System.Runtime.Serialization;

namespace Tba.CqrsEs.Domain.Enums
{
    public enum PackSize
    {
        [EnumMember(Value = "one")] One,
        [EnumMember(Value = "three")] Three,
        [EnumMember(Value = "six")] Six,
        [EnumMember(Value = "twelve")] Twelve
    }
}