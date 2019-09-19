using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumLeap.Components
{
    class Event
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime HistoricalDate { get; }
        public bool IsPutRight { get; set; }
        public String Location { get; }

        public Event(DateTime historicalDate, String location)
        {
            HistoricalDate = historicalDate;
            IsPutRight = false;
            Location = location;
        }
    }
}
