using QuantumLeap.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumLeap.Data
{
    class LeapRepository
    {
        static List<Leap> _leaps = new List<Leap>();

        public List<Leap> GetAll()
        {
            return _leaps;
        }
        public Leap GetLeapById(Guid leapId)
        {
            var requestedLeap = _leaps.Find(leap => leap.Id == leapId);
            return requestedLeap;
        }
        public void Add(Leap leap)
        {
            _leaps.Add(leap);
        }
        public string GetLeapHistory()
        {
            string leapLog = "";
            int leapIteration = 1;
            var eventRepo = new EventRepository();
            var leaperRepo = new LeaperRepository();
            var hostRepo = new HostRepository();
            foreach (var leap in _leaps)
            {
                var eventToLog = eventRepo.GetEventById(leap.EventId);
                var leaperToLog = leaperRepo.GetLeaperById(leap.LeaperId);
                var hostToLog = hostRepo.GetHostById(leap.HostId);
                var leapOrderInfo = "";
                
                if (leapIteration == 1)
                {
                    leapOrderInfo = $"{leapIteration} <-- First leap";
                } else if (leapIteration == _leaps.Count)
                {
                    leapOrderInfo = $"{leapIteration} <-- Most recent leap";
                } else
                {
                    leapOrderInfo = leapIteration.ToString();
                }

                leapIteration++;

                leapLog += $"{leapOrderInfo}\n";
                leapLog += $"Location: {eventToLog.Location}\n";
                leapLog += $"Date: {eventToLog.HistoricalDate.Date}\n";
                leapLog += $"Leaper: {leaperToLog.Name}\n";
                leapLog += $"Host: {hostToLog.Name}\n";
                leapLog += leapIteration == _leaps.Count ? "\n" : "";
            };
            return leapLog == "" ? "You haven't made any leaps yet.\n" : $"{leapLog}";
        }
    }
}
