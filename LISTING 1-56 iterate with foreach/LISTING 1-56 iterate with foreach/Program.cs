using System;

namespace LISTING_1_56_iterate_with_foreach
{
    /*
    
    The iterating value must match the type of the items in the collection.
    
    It isn't possible for code in a foreach construction to modigfy the iterating value.

    */
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Rob", "Mary", "David", "Jenny", "Chris", "Imogen" };

            //foreach (int name in names) 
            //Error CS0030  Cannot convert type 'string' to 'int'

            foreach (string name in names)
            {
                Console.WriteLine(name);

                // Error CS1656  Cannot assign to 'name' because it is a 'foreach iteration variable'
                //name = name.ToUpper();
            }

            Console.ReadKey();
        }
    }
}