using System;
using System.Collections.Concurrent;

namespace LISTING_1_38_Concurrent_stack
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentStack<string> stack = new ConcurrentStack<string>();
            stack.Push("Rob");
            stack.Push("Miles");

            string str;

            if (stack.TryPeek(out str))
                Console.WriteLine($"Peek: {str}.");
            if (stack.TryPop(out str))
                Console.WriteLine($"Pop: {str}.");

            Console.ReadKey();

            /*
            
            Peek: Miles.
            Pop: Miles.

            */
        }
    }
}
