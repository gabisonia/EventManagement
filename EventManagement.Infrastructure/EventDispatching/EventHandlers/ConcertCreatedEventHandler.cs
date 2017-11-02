﻿using EventManagement.EventHandlers;
using EventManagement.Events;
using EventManagement.Infrastructure.EventDispatching;

namespace Infrastructure.EventDispatching.EventDispatchers
{
    public class ConcertCreatedEventHandler : IHandle<ConcertCreated>
    {
        public void Handle(ConcertCreated @event)
        {
            new ConcertCreatedProjector().Project(@event);
        }
    }
}
