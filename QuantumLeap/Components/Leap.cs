using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumLeap.Components
{
    class Leap
    {
        public string Location { get; }
        public DateTime Date { get; }
        public Leaper Leaper { get; }
        public Host Host { get; }

        public Leap(string location, DateTime date, Leaper leaper, Host host)
        {
            Location = location;
            Date = date;
            Leaper = leaper;
            Host = host;
        }
    }
}
