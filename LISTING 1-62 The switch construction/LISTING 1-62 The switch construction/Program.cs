using System;

namespace LISTING_1_62_The_switch_construction
{
    /*
    
    The switch construction will switch on character, string and enumerated values, and it is possible to group cases.

    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter command: ");
            int command = int.Parse(Console.ReadLine());

            switch(command)
            {
                case 1:
                    Console.WriteLine("Command 1 chosen.");
                    break;
                case 2:
                    Console.WriteLine("Command 2 chosen.");
                    break;
                case 3:
                    Console.WriteLine("Command 3 chosen.");
                    break;
                default:
                    Console.WriteLine("Please enter a command in the range 1-3.");
                    break;
            }
            Console.ReadKey();

            // goto case
            Console.WriteLine("Coffee sizes: 1=Small 2=Medium 3=Large");
            Console.Write("Please enter your selection: ");

            string s = Console.ReadLine();
            int n = int.Parse(s);
            int cost = 0;

            switch (n)
            {
                case 1:
                    cost += 25;
                    break;
                case 2:
                    cost += 25;
                    goto case 1;
                case 3:
                    cost += 50;
                    goto case 1;
                default:
                    Console.WriteLine("Invalid selection.");
                    break;
            }
            if (cost != 0)
            {
                Console.WriteLine("Please insert {0} cents.", cost);
            }
            Console.WriteLine("Thank you for your business.");

            // Keep the console open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}