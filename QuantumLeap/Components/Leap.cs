using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumLeap.Components
{
    class Leap
    {
        public Guid Id { get; } = Guid.NewGuid();
        public Guid EventId { get; }
        public Guid LeaperId { get; }
        public Guid HostId { get; }

        public Leap(Guid eventId, Event _eventRepo, Guid leaperId, Guid hostId)
        {
            EventId = eventId;
            LeaperId = leaperId;
            HostId = hostId;
        }

        internal static object Last()
        {
            throw new NotImplementedException();
        }
    }
}
