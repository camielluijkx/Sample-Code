using System;
using System.Collections.Concurrent;

namespace LISTING_1_37_Concurrent_queue
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
            queue.Enqueue("Rob");
            queue.Enqueue("Miles");

            string str;

            if (queue.TryPeek(out str))
                Console.WriteLine($"Peek: {str}.");
            if (queue.TryDequeue(out str))
                Console.WriteLine($"Dequeue: {str}.");

            Console.ReadKey();

            /*
            
            Peek: Rob.
            Dequeue: Rob.

            */
        }
    }
}
