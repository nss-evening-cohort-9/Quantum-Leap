using QuantumLeap.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumLeap.Components
{
    public class UserInterface
    {
        Leaper _leaper;
        Lab _lab = new Lab();

        private void ChooseLeaperGui()
        {
            var leaperRepo = new LeaperRepository();
            var leapers = leaperRepo.GetAll();

            Console.WriteLine("Welcom to Quantum Leap. What is your name?\n");
            foreach (var leaper in leapers)
            {
                Console.WriteLine(leaper.Name);
            }
            Console.WriteLine();
            var selection = Console.ReadLine();
            _leaper = leapers.Find(leaper => leaper.Name.ToLower() == selection.ToLower());
            if (_leaper == null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, you do not appear to be an authorized leaper. Talk to Jason Lee Scott for more info, or try again.\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }


            while (_leaper == null)
            {
                Console.WriteLine("What is your name?\n");
                foreach (var leaper in leapers)
                {
                    Console.WriteLine(leaper.Name);
                }
                Console.WriteLine();
                selection = Console.ReadLine();
                _leaper = leapers.Find(leaper => leaper.Name.ToLower() == selection.ToLower());
                if (_leaper == null)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry, you do not appear to be an authorized leaper. Talk to Jason Lee Scott for more info, or try again.\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            Console.Clear();
        }
        public void DisplayUserInterface()
        {
            ChooseLeaperGui();

            Console.WriteLine($"Welcome back {_leaper.Name}, what would you like to do?\n");

            var selection = "";
            do
            {
                Console.WriteLine("Type \"leap\" to take a leap.");
                Console.WriteLine("Type \"fund\" to add more money to your budget.");
                Console.WriteLine("Type \"history\" for a list of your past leaps.");
                Console.WriteLine("Or type \"quit\" to close up shop and go home.\n");

                selection = Console.ReadLine();
                Console.Clear();

                switch (selection)
                {
                    case "history":
                        var leapRepo = new LeapRepository();
                        var leapHistory = leapRepo.GetLeapHistory();
                        Console.WriteLine($"{leapHistory}");

                        Console.WriteLine("What would you like to do next?\n");
                        break;
                    case "fund":
                        Console.WriteLine("Enter the amount.\n");
                        var fundAmount = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine($"You added ${fundAmount} to your budget.\n");

                        Console.WriteLine("What would you like to do next?\n");
                        break;
                    case "leap":
                        _lab.AttemptLeap();

                        Console.WriteLine("What would you like to do next?\n");
                        break;
                    case "quit":
                        Console.WriteLine($"Have a good night {_leaper.Name}.");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("That is an invalid request. Please try again.\n");
                        Console.ForegroundColor = ConsoleColor.Gray;

                        Console.WriteLine("What would you like to do?\n");
                        break;
                }

            }
            while (selection != "quit");
        }
    }
}
