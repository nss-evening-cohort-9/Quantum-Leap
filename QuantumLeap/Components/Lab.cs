using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumLeap.Components
{
    class Lab
    {
        public void AttemptLeap()
        {
            Console.WriteLine("\nNot yet implemented\n");
        }

        // Filter through events
        public void ButterflyEffect()
        {
            var LeapList = new List<Event>();
            LeapList.Add(new Event() { Location = "Las Vegas", HistoricalDate = 1996, isPutRight = false });
            LeapList.Add(new Event() { Location = "Overton High", HistoricalDate = 2004, isPutRight = true });
            LeapList.Add(new Event() { Location = "NSS", HistoricalDate = 2020, isPutRight = true });

            foreach(var e in LeapList)
                if(e.HistoricalDate >= 2000)
                {
                    Console.WriteLine(e);
                }
        }

        public class Event
        {
            public string Location { get; set; } 
            public int HistoricalDate { get; set; } 
            public bool isPutRight { get; set; } 
        }
    }
}
