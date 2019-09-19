using QuantumLeap.Components;
using QuantumLeap.Data;
using System;

namespace QuantumLeap
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ui = new UserInterface();
            //ui.DisplayUserInterface();
            HostRepository hostRepo = new HostRepository();
            Host randomHost = hostRepo.GetRandom();
            Console.WriteLine(randomHost.Name);
            Console.WriteLine(randomHost.Id);

            Host hostById = hostRepo.GetHostById(randomHost.Id);
            Console.WriteLine(hostById.Name);

            EventRepository eventRepo = new EventRepository();
            Event randomEvent = eventRepo.GetRandom();
            Console.WriteLine(randomEvent.Location);
            Console.WriteLine(randomEvent.Id);

            Event eventById = eventRepo.GetEventById(randomEvent.Id);
            Console.WriteLine(eventById.Location);
        }
    }
}
