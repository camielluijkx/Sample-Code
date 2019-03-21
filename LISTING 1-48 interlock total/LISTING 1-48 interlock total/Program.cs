using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_48_interlock_total
{
    /*
    
    There's a better way of achieving thread safe access to the contents of a variable, which is to use the Interlocked
    class. This provides a set of thread-safe operations that can be performed on a variable. These include increment, 
    decrement, exchange (swap a variable with another), and add. There is also a compare and exchange method that can 
    be used to create a multi-tasking program to search through an array and find the largest valuye in that array.

    */
    class Program
    {
        static long sharedTotal;

        // make an array that holds the values 0 to 5000000
        static int[] items = Enumerable.Range(0, 500001).ToArray();

        static void addRangeOfValues(int start, int end)
        {
            long subTotal = 0;

            while (start < end)
            {
                subTotal = subTotal + items[start];
                start++;
            }

            Interlocked.Add(ref sharedTotal, subTotal);
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

            //useVolatile();
        }

        /*
        
        After compilation we may find that the order of the first two statements has been swapped, so that the value in 
        x can be held inside the computer processor rather than having to be re-loaded from memory for the write 
        statement.

        In a single threaded situation this is perfectly acceptable, but if multiple threads are working on the code,
        this may result in unexpected behaviors. Furthermore, if another task changes the value of x whuile statements 
        are running, and if the C# compiler caches the value of x between statements, this results in an out of date 
        value being printed. C# provides the keyword volatile, which can be used to indicate that operations involving 
        a particular variable are not optimized in this way.

        Operations involving the variable x will now be optimized, and the value of x will be fetched from the copy in 
        memory, rather than being cached in the processor. This can make operations involving the variable x a lot less 
        efficient.

        */
        private static volatile int x;
        private static int y = 0;

        static void useVolatile()
        {
            x = 99;
            y = y + 1;
            Console.WriteLine($"The answer is: {x}.");

            /*
            
            The answer is: 99.

            */
        }
    }
}