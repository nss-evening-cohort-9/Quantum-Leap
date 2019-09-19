using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumLeap.Components
{
    class Leap
    {
        public Guid ID { get; set; }
        public string MyEvent { get; set; }
        public Event EventId { get; set; }
        public Leaper LeaperId { get; set; }

        public Leap()
        {

        }
    }
}
