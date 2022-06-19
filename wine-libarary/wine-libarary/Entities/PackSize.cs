using System.Runtime.Serialization;

namespace wine_libarary.Entities
{
    public enum PackSize
    {
        [EnumMember(Value="one")] One,
        [EnumMember(Value="three")] Three,
        [EnumMember(Value="six")] Six,
        [EnumMember(Value="twelve")] Twelve
    }
}