using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace LISTING_1_35_Using_BlockingCollection
{
    class Program
    {
        /*
        
        The program creates a thread that attempts to add 10 items to a BlockingCollection, which has been created to
        hold 5 items.

        After adding the 5th item this thread is blocked.

        The program also creates a thread that takes items out of the collection.

        As soon as the read thread starts running, and takes some items out of the collectionb, the writing thread can 
        continue.

        The adding task calls the CompleteAdding on the collection when it has added the last item.

        This prevents any more items from being added to the collection.

        The task taking from the collection uses the IsCompleted property of the collection to determine when to stop
        taking items from it.

        The IsCompleted property returns true when the collection is empty and CompleteAdding has been called.

        */
        static void Main(string[] args)
        {
            // blocking collection that can hold 5 items
            BlockingCollection<int> data = new BlockingCollection<int>(5);

            Task.Run(() =>
            {
                // attempt to add 10 items to the collection - blocks after 5th
                for (int i = 0; i < 10; i++)
                {
                    data.Add(i); // data.TryAdd (timeout, cancellation token)
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
                        int v = data.Take(); // data.TryTake (timeout, cancellation token)
                        Console.WriteLine($"Data {v} taken successfully.");
                    }
                    catch (InvalidOperationException)
                    {
                        /*
                        
                        Note that the Take method can throw an exception if the following sequence occurs:

                            1. The taking task checks the IsCompleted flag and finds that it is false.
                            2. The adding task (which is running at the same time as the taking task) then calls the
                               CompleteAdding method on the collection.
                            3. The taking task then tries to perform a Take from a collection which has been marked as
                               complete.
                        */
                    }
                }
            });

            Console.ReadKey();
        }
    }
}
