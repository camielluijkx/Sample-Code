using System;
using System.Threading;

namespace LISTING_1_19_Using_ThreadStart
{
    class Program
    {
        static void ThreadHello()
        {
            Console.WriteLine("Hello from the thread");
            Thread.Sleep(2000);
        }

        static void Main(string[] args)
        {
            // Use ThreadStart delegate to specify the method to be executed by the thread.
            ThreadStart ts = new ThreadStart(ThreadHello);
            Thread thread = new Thread(ts);
            thread.Start();

            Console.WriteLine("Press a key to end.");
            Console.ReadKey();

            /*
             
            Hello from the thread
            Press a key to end.

            OR

            Press a key to end.
            Hello from the thread

            */
        }
    }
}
