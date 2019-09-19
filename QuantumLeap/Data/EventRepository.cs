using QuantumLeap.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumLeap.Data
{
    class EventRepository
    {
        static readonly List<Event> _events = new List<Event>
        {
            new Event(new DateTime(2001, 09, 11), "New York"),
            new Event(new DateTime(1944, 06, 06), "Normandy"),
            new Event(new DateTime(2007, 09, 25), "Gamestop")
        };

        readonly Random random = new Random();

        public List<Event> GetAll()
        {
            return _events;
        }

        public Event GetEventById(Guid id)
        {
            Event requestedEvent = _events.Find(x => x.Id == id);
            return requestedEvent;
        }

        public Event GetRandom()
        {
            int randomIndex = random.Next(0, _events.Count);
            Event randomEvent = _events[randomIndex];
            return randomEvent;
        }
    }
}
