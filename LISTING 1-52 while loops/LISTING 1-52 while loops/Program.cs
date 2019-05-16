using System;

namespace LISTING_1_52_while_loops
{
    /*
    
    The condition that controls the looping behavior is tested before the statements controlled by the loop are obeyed.    
        
    A while loop is very effective when creating a consumer of data.     

    */
    class Program
    {
        static void Main(string[] args)
        {
            while (false)
            {
                Console.WriteLine("Hello");
            }

            int count = 0;
            while(count < 10)
            {
                Console.WriteLine($"Hello {count}");
                count = count + 1;
            }

            while (true)
            {
                Console.WriteLine("Hello");
            }
        }
    }
}