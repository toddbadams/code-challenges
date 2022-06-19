using System.Runtime.Serialization;

namespace Tba.CqrsEs.Application.Commands.RequestBodies
{
    public enum UpdateWineActions
    {
        [EnumMember(Value = "editDetails")] EditDetails,
        [EnumMember(Value = "consume")] Consume,
    }
}