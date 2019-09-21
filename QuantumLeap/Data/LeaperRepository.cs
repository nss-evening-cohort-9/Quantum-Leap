using QuantumLeap.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumLeap.Data
{
    class LeaperRepository
    {
        static readonly List<Leaper> _leapers = new List<Leaper>
        {
            new Leaper("Samuel"),
            new Leaper("Josh"),
            new Leaper("Andrew"),
            new Leaper("Sean")
        };

        public List<Leaper> GetAll()
        {
            return _leapers;
        }
        public void Add(Leaper leaper)
        {
            _leapers.Add(leaper);
        }
        public Leaper GetLeaperById(Guid leaperId)
        {
            var requestedLeaper = _leapers.Find(leaper => leaper.Id == leaperId);
            return requestedLeaper;
        }
    }
}