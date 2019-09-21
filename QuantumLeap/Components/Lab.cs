using QuantumLeap.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumLeap.Components
{
    class Lab
    {
        private int _budget = 100000;
        public int AddFunds(string fundAmount)
        {
            int newFunds = Int32.Parse(fundAmount);
            _budget += newFunds;
            return _budget;
        }

        public void SubtractFunds(int removeThisMuchMoney)
        {
            _budget -= removeThisMuchMoney;
        }

        public DateTime CurrentEventDate()
        {
            var leaps = new LeapRepository().GetAll();
            
            if (leaps.Count > 0)
            {
                var leap = leaps.Last();
                var currentEventId = leap.EventId;

                var currentEvent = new EventRepository().GetEventById(currentEventId);
                var eventDate = currentEvent.HistoricalDate;
                return eventDate;
            }
            else
            {
                var eventDate = DateTime.Now;
                return eventDate;
            }
        }

        public int DateDistance(DateTime currentEventDate, Event evnt)
        {
            DateTime newDate = evnt.HistoricalDate;
            TimeSpan difference = currentEventDate - newDate;
            return difference.Days;
        }

        public void AttemptLeap(Leaper leaper)
        {
            var randomEvent = new EventRepository().GetRandom();

            var randomHost = new HostRepository().GetRandom();

            var currentDate = CurrentEventDate();

            int eventsDateDifference = DateDistance(currentDate, randomEvent);
            
            int dailyCostOfTravel = 1000 * eventsDateDifference;

            if (dailyCostOfTravel > _budget)
            {
                Console.WriteLine("Not enough funds to leap.");
            } 
            else
            {
                Leap leap = new Leap(randomEvent.Id, randomEvent, leaper.Id, randomHost.Id);
                SubtractFunds(dailyCostOfTravel);
                LeapRepository makeLeap = new LeapRepository();
                makeLeap.Add(leap);
                Console.WriteLine($"Congrats, you have successfully leaped to {randomEvent.Location}.");
            }
        }
    }
}
