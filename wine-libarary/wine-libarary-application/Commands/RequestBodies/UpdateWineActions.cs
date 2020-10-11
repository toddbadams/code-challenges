using System.Runtime.Serialization;

namespace wine_libarary_application.Commands.RequestBodies
{
    public enum UpdateWineActions
    {
        [EnumMember(Value="editDetails")] EditDetails,
        [EnumMember(Value="consume")] Consume,
    }
}