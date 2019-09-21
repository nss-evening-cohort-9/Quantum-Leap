using QuantumLeap.Data;
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

            if(oldRightness != newRightness)
            {
                randEvent.IsPutRight = newRightness;
                Console.WriteLine($"You changed {randEvent.Location}");
            }
            else
            {
                Console.WriteLine("You didn't change the future of our existence.");
            }
        }
    }
}
