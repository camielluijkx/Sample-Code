﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_2_ParallelForEach_in_use
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
            var items = Enumerable.Range(0, 500);

            // The Parallel.ForEach method accepts two parameters.
            // The first parameter is an IEnumerable collection.
            // The second parameter provides the action to be performed on each item in the collection.
            // Note that the tasks are not completed in the same order that they were started.
            Parallel.ForEach(items, item =>
            {
                WorkOnItem(item);
            });

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }

    }
}
