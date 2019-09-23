using QuantumLeap.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumLeap.Components
{
    class Lab
    {
        private int _budget = 20000000;
        private int _maxBudget = 999999999;

        // Filter through events
        public void ButterflyEffect(Event currentEvent)
        {
            var allEvents = new EventRepository().GetAll();

            var futureEvents = allEvents.FindAll(x => x.HistoricalDate > currentEvent.HistoricalDate);
            if (futureEvents.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The time continum is still intact.\n");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Random rand = new Random();
            var randIndex = rand.Next(0, futureEvents.Count - 1);
            var randEvent = futureEvents[randIndex];

            bool newRightness = Convert.ToBoolean(rand.Next(0, 2));

            bool oldRightness = randEvent.IsPutRight;

            if (oldRightness != newRightness)
            {
                randEvent.IsPutRight = newRightness;
                Console.ForegroundColor = ConsoleColor.Yellow;
                var futureDate = $"{randEvent.HistoricalDate.Month}/{randEvent.HistoricalDate.Day}/{randEvent.HistoricalDate.Year}";
                var currentDate = $"{currentEvent.HistoricalDate.Month}/{currentEvent.HistoricalDate.Day}/{currentEvent.HistoricalDate.Year}";
                Console.WriteLine($"You affected the future reality of {randEvent.Location}, {futureDate}, by visiting {currentEvent.Location}, {currentDate}.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The time continum is still intact.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public int AddFunds(string fundAmount)
        {
            if (fundAmount.Length > 9)
            {
                fundAmount = fundAmount.Remove(9);
            }
            int newFunds = Int32.Parse(fundAmount);
            _budget += newFunds;
            if (_budget > _maxBudget)
            {
                _budget = _maxBudget;
            }
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

        public bool isLeapIdentical(Event randomEvent, Host randomHost)
        {
            var leaps = new LeapRepository().GetAll();
            if (leaps.Count < 1)
            {
                return false;
            }
            var getLastLeap = leaps.Last();
            var lastHostId = getLastLeap.HostId;
            var lastEventId = getLastLeap.EventId;
            if (lastHostId == randomHost.Id && lastEventId == randomEvent.Id)
            {
                return true;
            }
            else
            {
                return false;
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
            Event randomEvent;
            Host randomHost;

            while (true)
            {
                randomEvent = new EventRepository().GetRandom();

                randomHost = new HostRepository().GetRandom();

                bool compareHostAndEventWithLastLeap = isLeapIdentical(randomEvent, randomHost);
                if (!compareHostAndEventWithLastLeap)
                {
                    break;
                }
            }

            var currentDate = CurrentEventDate();

            int eventsDateDifference = DateDistance(currentDate, randomEvent);

            int dailyCostOfTravel = 1000 * eventsDateDifference;

            if (dailyCostOfTravel > _budget)
            {
                Console.WriteLine($"Not enough funds to leap to that spot in time. \nYour current budget is only ${_budget}.\n");
            }
            else
            {
                Leap leap = new Leap(randomEvent.Id, leaper.Id, randomHost.Id);
                SubtractFunds(dailyCostOfTravel);
                LeapRepository makeLeap = new LeapRepository();
                makeLeap.Add(leap);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Congrats {leaper.Name}, you have leaped into {randomHost.Name}. You are at {randomEvent.Location} in the year {randomEvent.HistoricalDate.Year}\n");
                Console.ForegroundColor = ConsoleColor.White;

                ButterflyEffect(randomEvent);
            }
        }
    }
}