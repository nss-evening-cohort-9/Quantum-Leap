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
        public string GetLeapHistory()
        {
            return "\nayy no history lmao\n";
        }
    }
}
