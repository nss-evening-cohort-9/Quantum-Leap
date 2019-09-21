using QuantumLeap.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumLeap.Data
{
    class HostRepository
    {
        static readonly List<Host> _hosts = new List<Host> {
            new Host("Elvis Presley"),
            new Host("Dolly Parton"),
            new Host("Richard Nixon"),
            new Host("Adolf Hitler")
        };

        readonly Random random = new Random();

        public List<Host> GetAll()
        {
            return _hosts;
        }

        public Host GetHostById(Guid id)
        {
            Host requestedEvent = _hosts.Find(x => x.Id == id);
            return requestedEvent;
        }

        public Host GetRandom()
        {
            int randomIndex = random.Next(0, _hosts.Count);
            Host randomHost = _hosts[randomIndex];
            return randomHost;
        }
    }
}
