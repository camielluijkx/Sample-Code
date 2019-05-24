using System;
using System.Threading;

namespace LISTING_1_25_Using_join
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread threadToWaitFor = new Thread(() =>
            {
                Console.WriteLine("Thread starting.");
                Thread.Sleep(2000);
                Console.WriteLine("Thread done.");
            });
            threadToWaitFor.Start();

            Console.WriteLine("Joining thread.");

            /*
            
            The join method allows two threads to synchronize. 
            
            When a thread calls the join method on another thread, the caller of join is held until the other thread
            completes.

            */

            threadToWaitFor.Join(); // Thread.Current calls join on (thus waits for) threadToWaitFor

            Console.WriteLine("Press a key to exit.");
            Console.ReadKey();

            /*
            
            Joining thread.
            Thread starting.
            Thread done.
            Press a key to exit.

            */
        }
    }
}