using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_4_Managing_a_parallel_For_loop
{
    class Program
    {
        static void WorkOnItem(object item)
        {
            Console.WriteLine("Started working on: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Finished working on: " + item);
        }

        static void Main(string[] args)
        {
            //var items = Enumerable.Range(0, 10).ToArray();
            int[] items = Enumerable.Range(0, 10).ToArray();

            // The lambda expression that executes each iteration of the loop can be provided with an additional
            // parameter of type ParallelLoopState that allows the code being iterated to control the iteration 
            // process.
            // The For and ForEach methods also return a value of type ParallelLoopResult that can be used to determine 
            // whether or not a parallel loop has successfully completed.
            // Note that this doesn't mean that the iterator will instantly stop any executing iterations.
            // Note also that this doesn't mean that work items with a number greater than 5 will never run, because
            // there is no guarantee that the work item with number 5 (which triggers the stop) will run before work 
            // items with higher numbers.

            // Calling Stop will prevent any new iterations with an index value greater than the current index.
            // If Stop is used to stop the loop during the 200th iteration it might be that iterations with an 
            // index lower than 5 will not be performed. 
            // If Break is used to end the loop iteration, all the iterations with an index lower than 5 are 
            // guaranteed to be completed before the loop is ended.

            //Action<int, ParallelLoopState> itemAction = new Action<int, ParallelLoopState>((i, loopState) =>
            //{
            //    if (i == 5)
            //        //loopState.Break();
            //        loopState.Stop();

            //    WorkOnItem(items[i]); // might not be performed when ParallelLoopState.Stop is used
            //});
            //ParallelLoopResult result = Parallel.For(0, items.Count(), itemAction);

            ParallelLoopResult result = Parallel.For(0, items.Count(), (int i, ParallelLoopState loopState) =>
            {
                if (i == 5)
                    //loopState.Break();
                    loopState.Stop();

                WorkOnItem(items[i]); // might not be performed when ParallelLoopState.Stop is used
            });

            Console.WriteLine("Completed: " + result.IsCompleted); // false in both cases
            Console.WriteLine("Items: " + result.LowestBreakIteration); // null on stop, 5 on break

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}