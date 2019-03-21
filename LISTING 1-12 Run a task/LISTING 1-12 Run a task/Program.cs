using System;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_12_Run_a_task
{
    class Program
    {
        public static void DoWork()
        {
            Console.WriteLine("Work starting.");
            Thread.Sleep(2000);
            Console.WriteLine("Work finished.");
        }

        /*
        
        Run a task (create and start) and wait for it to complete.

        */
        static void Main(string[] args)
        {
            Console.WriteLine("Task start (begin).");
            Task newTask = Task.Run(() => DoWork());
            Console.WriteLine("Task start (end).");
            Console.WriteLine("Task wait (begin).");
            newTask.Wait();
            Console.WriteLine("Task wait (end).");

            /*
             
            Task start (begin).
            Task start (end).
            Task wait (begin).
            Work starting.
            Work finished.
            Task wait (end).
            
            */
        }
    }
}