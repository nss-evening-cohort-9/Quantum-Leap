using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumLeap.Components
{
    class Event
    {
        public Guid EventId { get; } = Guid.NewGuid();
    }
}
