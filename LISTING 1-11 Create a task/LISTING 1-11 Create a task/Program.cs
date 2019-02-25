using System;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_11_Create_a_task
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
            // Create a task, start it and wait for it to complete.
            Task newTask = new Task(() => DoWork());
            Console.WriteLine("Task start (begin)");
            newTask.Start();
            Console.WriteLine("Task start (end)");
            Console.WriteLine("Task wait (begin)");
            newTask.Wait();
            Console.WriteLine("Task wait (end)");

            /*
            
            Task start (begin)
            Task start (end)
            Task wait (begin)
            Work starting
            Work finished
            Task wait (end)

            */
        }
    }
}
