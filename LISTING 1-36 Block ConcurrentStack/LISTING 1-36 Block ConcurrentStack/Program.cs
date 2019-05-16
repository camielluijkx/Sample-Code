using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace LISTING_1_36_Block_ConcurrentStack
{
    class Program
    {
        /*
        
        The BlockingCollection class can act as a wrapper around the other concurrent collection classes, including
        ConcurrentQueue, ConcurrentStack and ConcurrentBag.

        The collection class to be used is given as the first parameter of the BlockingCollection constructor.

        If you don't provide a collection class the BlockingCollection class uses a ConcurrentQueue, which operates on 
        a "first in-first out" basis.

        Items are added and taken from the stack on a "last in-first out" basis when a ConcurrentStack is used.
        
        */
        static void Main(string[] args)
        {
            // blocking collection that can hold 5 items
            BlockingCollection<int> data = new BlockingCollection<int>(new ConcurrentStack<int>(), 5);

            Task.Run(() =>
            {
                // attempt to add 10 items to the collection - blocks after 5th
                for (int i = 0; i < 10; i++)
                {
                    data.Add(i);
                    Console.WriteLine($"Data {i} added successfully.");
                }

                // indicate we have no more to add
                data.CompleteAdding();
            });

            Console.ReadKey();
            Console.WriteLine("Reading collection.");

            Task.Run(() =>
            {
                while (!data.IsCompleted)
                {
                    try
                    {
                        int v = data.Take();
                        Console.WriteLine($"Data {v} taken successfully.");
                    }
                    catch (InvalidOperationException) { }
                }
            });

            Console.ReadKey();
        }
    }
}
