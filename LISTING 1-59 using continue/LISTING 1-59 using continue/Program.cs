using System;

namespace LISTING_1_59_using_continue
{
    /*
    
    The continue statement does not cause a loop to end. Instead, it ends the current pass through the code controlled
    by the loop. The terminating condition is then tested to determine if the loop should continue.
        
    */
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Rob", "Mary", "David", "Jenny", "Chris", "Imogen" };

            for (int index = 0; index < names.Length; index++)
            {
                if (names[index] == "David")
                {
                    continue;
                }

                Console.WriteLine(names[index]);
            }
            Console.ReadKey();
        }
    }
}