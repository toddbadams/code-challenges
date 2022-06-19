using System.Runtime.Serialization;

namespace Tba.CqrsEs.Domain.Enums
{
    public enum WineColorType
    {
        [EnumMember(Value = "lemon")] Lemon,
        [EnumMember(Value = "gold")] Gold,
        [EnumMember(Value = "amber")] Amber,
        [EnumMember(Value = "brown")] Brown,
        [EnumMember(Value = "pink")] Pink,
        [EnumMember(Value = "pink-orange")] PinkOrange,
        [EnumMember(Value = "orange")] Orange,
        [EnumMember(Value = "ruby")] Ruby,
        [EnumMember(Value = "garnet")] Garnet,
        [EnumMember(Value = "tawny")] Tawny
    }
}