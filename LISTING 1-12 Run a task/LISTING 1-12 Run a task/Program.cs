using System;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_12_Run_a_task
{
    class Program
    {
        public static void DoWork()
        {
            Console.WriteLine("Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work finished");
        }

        static void Main(string[] args)
        {
            // Run a task (create and start) and wait for it to complete.

            Console.WriteLine("Task run (begin)");
            Task newTask = Task.Run(() => DoWork());
            Console.WriteLine("Task run (end)");
            Console.WriteLine("Task wait (begin)");
            newTask.Wait();
            Console.WriteLine("Task wait (end)");

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();

            /*
             
            Task run (begin)
            Task run (end)
            Task wait (begin)
            Work starting
            Work finished
            Task wait (end)
            
            Finished processing. Press a key to end.

            */
        }
    }
}