using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumLeap.Components
{
    class Leaper
    {

        public Guid Id { get; } = Guid.NewGuid();

        public string Name { get; }

        public Leaper(string name)
        {
            Name = name;
        }
    }
}
