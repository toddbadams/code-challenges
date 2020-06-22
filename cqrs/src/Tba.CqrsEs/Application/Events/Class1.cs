using System;
using System.Collections.Generic;
using System.Text;

namespace Tba.CqrsEs.Application.Events
{
    public interface IEventFactory
    {
    }

    public class EventFactory
    {

    }

    public abstract class WineEventBase
    {

    }

    public class WineCreatedEvent : WineEventBase
    {

    }

    public class WineUpdatedEvent : WineEventBase
    {

    }
}
