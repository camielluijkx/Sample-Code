using System;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_15_Continuation_tasks
{
    class Program
    {
        public static void HelloTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Hello");
        }

        public static void WorldTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("World");
        }

        static void Main(string[] args)
        {
            // A continuous task can be nominated to start when an existing task (the antecedent task) finishes.
            // If the antecedent task produces a result, it can be supplied as an input to the continuation task.
            // Continuation tasks can be used to create a "pipeline" of operations, with each successive stage starting
            // when the preceding one ends.
            // A Task object exposes a ContinueWith method that can be used to specify a continuation task.
            // The lambda expression that executes the continuation task is provided with a reference to the antecedent
            // task, which it can use to determine if the antecedent completed successfully.
            // You can add continuation tasks to tasks that deliver a result, in which case the continuation task can
            // use the Result property of the antecedent task to obtain its input data.
            Task task = Task.Run(() => HelloTask());
            task.ContinueWith( (prevTask) => WorldTask());

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
