using System;

namespace LISTING_1_54_for_loops
{
    /*
    
    A loop that is not infinite (one that should terminate at some point) can be made up of three things:

        1. Initialization that is performed to set up the loop.
        2. A test that will determine if the loop should continue.
        3. An update to be performed each time the action of the loop has been performed.
        
    */
    class Program
    {
        static int counter;

        static void initalize()
        {
            Console.WriteLine("Initialize called.");
            counter = 0;
        }

        static void update()
        {
            Console.WriteLine("Update called.");
            counter = counter + 1;
        }

        static bool test()
        {
            Console.WriteLine("Test called.");
            return counter < 5;
        }
        static void Main(string[] args)
        {
            for (initalize(); test(); update())
            {
                Console.WriteLine($"Hello {counter}.");
            }
            Console.ReadKey();
        }
    }
}