using System;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_13_Task_returning_a_value
{
    class Program
    {
        public static int CalculateResult()
        {
            Console.WriteLine("Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work finished");
            return 99;
        }
        static void Main(string[] args)
        {
            // A task can be created that will return a value.
            // A program will wait for the task to deliver the result when the Result property of the Task instance is 
            // read.
            // The Task.Run method uses the TaskFactory.StartNew method to create and start the task, using the default
            // task scheduler that uses the .NET framework thread pool.
            // The Task class exposes a Factory property that refers to the default task scheduler.
            // You can create your own task scheduler or run a task scheduler in the synchronization context of another
            // processor. 
            // You can also create your own TaskFactory if you want to create a number of tasks with the same 
            // configuration.

            Console.WriteLine("Task run (begin)");
            Task<int> task = Task.Run(() =>
            {
                return CalculateResult();
            });
            Console.WriteLine("Task run (end)");

            Console.WriteLine(task.Result); // await
            
            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();

            /*
            
            Task run (begin)
            Task run (end)
            Work starting
            Work finished
            99
            Finished processing. Press a key to end.

            */
        }
    }
}