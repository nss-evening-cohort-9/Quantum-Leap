﻿using QuantumLeap.Data;
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

        // Filter through events
        public void ButterflyEffect(DateTime leapDate)
        {
            var allEvents = new EventRepository().GetAll();

            var futureEvents = allEvents.FindAll(x => x.HistoricalDate > leapDate);

            Random rand = new Random();
            var randIndex = rand.Next(0, futureEvents.Count);
            var randEvent = futureEvents[randIndex];

            bool newRightness = Convert.ToBoolean(rand.Next(0, 1));
            //bool newRightness = true;

            bool oldRightness = randEvent.IsPutRight;

            if (oldRightness != newRightness)
            {
                randEvent.IsPutRight = newRightness;
                Console.WriteLine($"You changed {randEvent.Location}");
            }
            else
            {
                Console.WriteLine("You didn't change the future of our existence.");
            }
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
                    Console.WriteLine($"Not enough funds to leap. {_budget}");
                }
                else
                {
                    Leap leap = new Leap(randomEvent.Id, leaper.Id, randomHost.Id);
                    SubtractFunds(dailyCostOfTravel);
                    LeapRepository makeLeap = new LeapRepository();
                    makeLeap.Add(leap);
                    Console.WriteLine($"Congrats, you have successfully leaped to {randomEvent.Location}.");
                }
            }
    }
}
