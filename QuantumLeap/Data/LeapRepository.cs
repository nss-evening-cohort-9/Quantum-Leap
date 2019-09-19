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
        public string GetLeapHistoryAsString()
        {
            var leapHistory = "";
            //_leaps.Select(leap =>
            //{
            //    var leapLog = $"Location: {leap.Location}\n";
            //    leapLog += $"Date: {leap.Date}\n";
            //    leapLog += $"Leaper: {leap.Leaper}\n";
            //    leapLog += $"Host: {leap.Host}\n\n";
            //    return leapLog;
            //});
            return leapHistory;
        }
    }
}
