using QuantumLeap.Components;
using System;

namespace QuantumLeap
{
    class Program
    {
        static void Main(string[] args)
        {
            var ui = new UserInterface();
            ui.DisplayUserInterface();

            var bfe = new Lab();
            bfe.ButterflyEffect();
        }
    }
}
