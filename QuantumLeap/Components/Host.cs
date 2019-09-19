using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumLeap.Components
{
    class Host
    {
        public String Name { get; }
        public Guid Id { get; } = Guid.NewGuid();

        public Host(String name)
        {
            Name = name;
        }
    }
}
