using System;
using System.Threading;

namespace LISTING_1_24_shared_flag_variable
{
    class Program
    {
        static bool tickRunning = true; // flag variable 

        static void Main(string[] args)
        {
            tickRunning = true;

            Thread tickThread = new Thread(() =>
            {
                /*
                
                A better way to abort a thread is to use a shared flag variable.
                
                */

                while (tickRunning)
                {
                    Console.WriteLine("Tick");
                    Thread.Sleep(1000);
                }

                if (!tickRunning)
                {
                    Console.WriteLine("Terminated");
                }
            });
            tickThread.Start();

            Console.WriteLine("Press a key to stop the clock.");
            Console.ReadKey();

            tickRunning = false;

            Console.WriteLine("Press a key to exit.");
            Console.ReadKey();

            /*
             
            Press a key to stop the clock.
            Tick
            ...
            Tick
            Press a key to exit.
            Terminated

            */
        }
    }
}