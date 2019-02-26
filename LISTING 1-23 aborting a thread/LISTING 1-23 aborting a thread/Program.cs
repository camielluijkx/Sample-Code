using System;
using System.Threading;

namespace LISTING_1_23_aborting_a_thread
{
    class Program
    {
        static void Main(string[] args)
        {

            Thread tickThread = new Thread(() =>
            {
                while (true)
                {
                    Console.WriteLine("Tick");
                    Thread.Sleep(1000);
                }
            });
            tickThread.Start();

            Console.WriteLine("Press a key to stop the clock");
            Console.ReadKey();

            // A Thread object exposes an Abort method, which can be called on the thread to abort it.
            // The thread is terminated instantly, which might mean that it leaves the program in an ambigious state, 
            // with files open and resources assigned.
            tickThread.Abort();

            Console.WriteLine("Press a key to exit");
            Console.ReadKey();

            /*
             
            Press a key to stop the clock
            Tick x?
            Press a key to exit

            */
        }
    }
}
