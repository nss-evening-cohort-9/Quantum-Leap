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

            Console.WriteLine("Welcom to Quantum Leap. What is your name.\n");
            foreach (var leaper in leapers)
            {
                Console.WriteLine(leaper.Name);
            }
            Console.WriteLine();
            var selection = Console.ReadLine();
            _leaper = leapers.Find(leaper => leaper.Name.ToLower() == selection.ToLower());
            if (_leaper == null)
            {
                Console.WriteLine("\nSorry, you do not appear to be an authorized leaper. Talk to Jason Lee Scott for more info.\n");
            }


            while (_leaper == null)
            {
                Console.WriteLine("Choose your leaper by typing their name.\n");
                foreach (var leaper in leapers)
                {
                    Console.WriteLine(leaper.Name);
                }
                Console.WriteLine();
                selection = Console.ReadLine();
                _leaper = leapers.Find(leaper => leaper.Name.ToLower() == selection.ToLower());
                if (_leaper == null)
                {
                    Console.WriteLine("\nThat user does not exist. Please try again.\n");
                }
            }
        }
        public void DisplayUserInterface()
        {
            ChooseLeaperGui();

            Console.WriteLine($"\nWelcome back {_leaper.Name}, what would you like to do?\n");

            var selection = "";
            do
            {
                Console.WriteLine("Type \"leap\" to take a leap.");
                Console.WriteLine("Type \"fund\" to add more money to your budget.");
                Console.WriteLine("Type \"history\" for a list of your past leaps.");
                Console.WriteLine("Or type \"quit\" to close up shop and go home.\n");

                selection = Console.ReadLine();

                switch (selection)
                {
                    case "history":
                        var leapRepo = new LeapRepository();
                        var leapHistory = leapRepo.GetLeapHistory();
                        Console.WriteLine();
                        Console.WriteLine(leapHistory);
                        break;
                    case "fund":
                        Console.WriteLine("\nEnter the amount.\n");
                        var fundAmount = Console.ReadLine();
                        Console.WriteLine($"\nYou added ${fundAmount} to your budget.\n");
                        break;
                    case "leap":
                        _lab.AttemptLeap();
                        break;
                    case "quit":
                        Console.WriteLine($"\nHave a good night {_leaper.Name}.");
                        break;
                    default:
                        Console.WriteLine("\nThat is an invalid request. Please try again.\n");
                        break;
                }

            }
            while (selection != "quit");
        }
    }
}
