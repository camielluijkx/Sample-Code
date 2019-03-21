using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LISTING_1_43_Using_locking
{
    /*
    
    A program can use locking to ensure that a given action is atomic.

    Atomic actions are preformed to completion, so they cannot be interrupted.

    */
    class Program
    {
        static long sharedTotal;

        // make an array that holds the values 0 to 5000000
        static int[] items = Enumerable.Range(0, 500001).ToArray();

        static object sharedTotalLock = new object();

        static void addRangeOfValues(int start, int end)
        {
            while (start < end)
            {
                lock (sharedTotalLock) // tasks are not executing in parallel anymore
                {
                    sharedTotal = sharedTotal + items[start];
                }
                start++;
            }
        }

        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();

            int rangeSize = 1000;
            int rangeStart = 0;

            while (rangeStart < items.Length)
            {
                int rangeEnd = rangeStart + rangeSize;
                if (rangeEnd > items.Length)
                {
                    rangeEnd = items.Length;
                }

                // create local copies of the parameters
                int rs = rangeStart;
                int re = rangeEnd;

                tasks.Add(Task.Run(() => addRangeOfValues(rs, re)));
                rangeStart = rangeEnd;
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine($"The total is: {sharedTotal}.");
            Console.ReadKey();

            /*
            
            The total is: 125000250000.

            */
        }
    }
}