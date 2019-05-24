using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LISTING_1_42_Bad_task_interaction
{
    /*
        
    The first task will add the values in the elements from 0 to 999, the second task will add the values in the 
    elements 1000 to 1999, and so on up the array.

    The main method creates all of the tasks ans then uses the Task.WaitAll method to cause the program to wait for the 
    completion of all tasks.

    Race condition

    There is a race between two threads, and the behavior of the program is dependent on which threads first get to the 
    sharedTotal variable. It is impossible to predict value for sharedTotal.

    Consider for example the following sequence of events:

        1. Task number 1 starts performing an update of sharedTotal. It fetches the contens of the sharedTotal variable 
           into the CPU and adds the contents of an array element to the value of sharedTotal. Just as the CPU is about 
           to write the result back into memory, the operating system stops task number 1 and switches to task number 
           2.
        2. Task number 2 also wants to update sharedTotal. It fetches the content of sharedTotal, adds the value of an 
           array element to it, and then writes the reuslt back into memory. Now the operating system returns control 
           to task number 1.
        3. Task number 1 writes the sharedTotal value it was working on from the CPU back into memory. This means that 
           the update performed by task number 2 has been lost.

    Note this threading issue can arise even if you se C# statements that look like they are atomic:

        x += 1; // this is not an atomic operation, it involves reading, updating and storing the result 

    */
    class Program
    {
        static long sharedTotal;

        // make an array that holds the values 0 to 5000000
        static int[] items = Enumerable.Range(0, 500001).ToArray();

        static void addRangeOfValues(int start, int end)
        {
            while (start < end)
            {
                sharedTotal = sharedTotal + items[start];
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
            
            The total is: ???.

            */
        }
    }
}