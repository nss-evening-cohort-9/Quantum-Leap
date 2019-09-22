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

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcom to Quantum Leap. What is your name?\n");

            foreach (var leaper in leapers)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(leaper.Name);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            var selection = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            _leaper = leapers.Find(leaper => leaper.Name.ToLower() == selection.ToLower());
            if (_leaper == null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Sorry, you do not appear to be an authorized leaper. Talk to Jason Lee Scott for more info, or try again.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }


            while (_leaper == null)
            {
                Console.WriteLine("What is your name?\n");
                foreach (var leaper in leapers)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(leaper.Name);
                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.WriteLine();
                selection = Console.ReadLine();
                _leaper = leapers.Find(leaper => leaper.Name.ToLower() == selection.ToLower());
                if (_leaper == null)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Sorry, you do not appear to be an authorized leaper. Talk to Jason Lee Scott for more info, or try again.\n");
                    Console.ForegroundColor = ConsoleColor.White;
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
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Type");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" \"leap\" ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("to take a leap.");

                Console.Write("Type");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" \"fund\" ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("to add more money to your budget.");

                Console.Write("Type");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" \"history\" ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("for a list of your past leaps.");

                Console.Write("Type");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" \"quit\" ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("to close up shop and go home.\n");
                Console.ForegroundColor = ConsoleColor.White;

                selection = Console.ReadLine();
                Console.Clear();

                switch (selection)
                {
                    case "history":
                        var leapRepo = new LeapRepository();
                        var leapHistory = leapRepo.GetLeapHistory();

                        if (leapHistory == "You haven't made any leaps yet.\n")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(leapHistory);
                            Console.ForegroundColor = ConsoleColor.White;
                        } else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(leapHistory);
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        Console.WriteLine("What would you like to do next?\n");
                        break;
                    case "fund":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Enter the amount.\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        var fundAmount = Console.ReadLine();
                        var budget = _lab.AddFunds(fundAmount);
                        Console.WriteLine();
                        Console.WriteLine($"You added ${fundAmount} to your budget. Your budget is ${budget}.\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("What would you like to do next?\n");
                        break;
                    case "leap":
                        _lab.AttemptLeap(_leaper);

                        Console.WriteLine("What would you like to do next?\n");
                        break;
                    case "quit":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Have a good night {_leaper.Name}.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("That is an invalid request. Please try again.\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine($"What would you like to do {_leaper.Name}?\n");
                        break;
                }

            }
            while (selection != "quit");
        }
    }
}
