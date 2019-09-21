using QuantumLeap.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumLeap.Components
{
    class Lab
    {

        public int AddFunds(string fundAmount)
        {
            int newFunds = Int32.Parse(fundAmount);
            var budget = 100000 + newFunds;
            return budget;
        }

        public DateTime CurrentLocation()
        {
            var leaps = new LeapRepository();
            //if (leaps)
            var location = DateTime.Now;
            return location;
        }

        public void AttemptLeap(Leaper leaper)
        {
            var eventRepo = new EventRepository().GetRandom();

            var hostRepo = new HostRepository().GetRandom();

            Leap leap = new Leap(eventRepo.Id, eventRepo, leaper.Id, hostRepo.Id);

            // Console.WriteLine("\nNot yet implemented\n");
        }
    }
}
