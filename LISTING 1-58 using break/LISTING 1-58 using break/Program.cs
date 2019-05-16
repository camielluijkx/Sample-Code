using System;

namespace LISTING_1_58_using_break
{
    /*
    
    When the break statement is reached, the program immediatly exits the loop.
    
    */
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Rob", "Mary", "David", "Jenny", "Chris", "Imogen" };

            for (int index = 0; index < names.Length; index++)
            {
                Console.WriteLine(names[index]);
                if (names[index] == "David")
                {
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}