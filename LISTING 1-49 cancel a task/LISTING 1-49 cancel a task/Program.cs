using System;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_49_cancel_a_task
{
    /*
    
    There is an important difference between threads and tasks, in that a Thread can be aborted at any time, whereas a 
    Task must monitor a cancellation token so that it will end when told to.   

    */
    class Program
    {
        static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        static void Clock()
        {
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                Console.WriteLine("Tick");
                Thread.Sleep(500);
            }
        }

        static void Main(string[] args)
        {
            Task.Run(() => Clock());

            Console.WriteLine("Press any key to stop the clock.");
            Console.ReadKey();

            cancellationTokenSource.Cancel();

            Console.WriteLine("Clock stopped.");
            Console.ReadKey();

            /*
             
            Press any key to stop the clock.
            Tick
            ...
            Tick
            Tick
            Tick
            Tick
            Clock stopped.

            */
        }
    }
}
