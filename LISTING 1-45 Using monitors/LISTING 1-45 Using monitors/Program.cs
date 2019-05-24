using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_45_Using_monitors
{
    /*
         
    A monitor provides a similar set of actions to a lock, but the code is arranged slightly differently. They allow a 
    program to ensure that only one thread at a time can access a particular object. Rather than controlling a 
    statement or block of code, as the lock keyword does, the atomic code is enclosed in calls of Monitor.Enter and 
    Monitor.Exit. The Enter and Exit methods are passed a reference to an object that is used as the lock.

    If atomic code throws an exception, you need to be sure that any locks that have been claimed to enter the code are 
    released. In statements managed by the lock keyword this happens automatically. If you use a monitor, make sure 
    the lock is released.

        lock is similar to Monitor.Enter with try + finally and Monitor.Exit
        use lock statement whenever it is enough - otherwise use try + Monitor.TryEnter + finally
    
    try
    {
        if (Monitor.TryEnter(lockObject)) // might throw an exception
        {
            // code controlled by the lock
        }
        else 
        {
            // do something else because the lock object is in use
        }
    }
    finally
    {
        Monitor.Exit(lockObject);
    }

    */
    class Program
    {
        static long sharedTotal;

        // make an array that holds the values 0 to 5000000
        static int[] items = Enumerable.Range(0, 500001).ToArray();

        static object sharedTotalLock = new object();

        static void addRangeOfValues(int start, int end)
        {
            long subTotal = 0;

            while (start < end)
            {
                subTotal = subTotal + items[start];
                start++;
            }

            Monitor.Enter(sharedTotalLock);
            sharedTotal = sharedTotal + subTotal;
            Monitor.Exit(sharedTotalLock);
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