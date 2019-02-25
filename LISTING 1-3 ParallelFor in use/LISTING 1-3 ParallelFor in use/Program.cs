using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_3_ParallelFor_in_use
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
            var items = Enumerable.Range(0, 500).ToArray();

            // The Parallel.For method accepts three parameters.
            // The first and second parameter represent start and end index for iteration of the collection.
            // The third parameter represents the delegate that is invoked once per iteration.
            // Note that the tasks are not completed in the same order that they were started.
            Parallel.For(0, items.Length, i =>
            {
                WorkOnItem(items[i]);
            });

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
