using System;

namespace DrankAutomaat
{
    class Program
    {
        static void Main(string[] args)
        {
            //drankautomaat drankautomaat = new drankautomaat();

            decimal userMoney = 0.0m;
            int userChoice = 0;
            Drankautomaat automaat1 = new Drankautomaat(4, 1, 0);

            while (true)
            {
                bool validUserchoice = false;
                bool validUsermoney = false;
                Console.WriteLine(automaat1.ToString()+"\n");
                Console.WriteLine("Stop bedrag in automaat");
                validUsermoney = decimal.TryParse(Console.ReadLine(), out userMoney);
                Console.WriteLine("\nMaak uw keuze");
                validUserchoice = int.TryParse(Console.ReadLine(), out userChoice);
                if (!validUserchoice || !validUsermoney)
                {
                    if (!validUserchoice)
                    {
                        Console.WriteLine("Geen geldige keuze");
                    }
                    if (!validUsermoney)
                    {
                        Console.WriteLine("Geen geldige bedrag");
                    }
                }
                else
                {
                    Console.WriteLine(automaat1.Keuze(userChoice, userMoney));
                }
            }

        }
    }
}

