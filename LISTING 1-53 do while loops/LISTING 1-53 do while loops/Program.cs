using System;

namespace LISTING_1_53_do_while_loops
{
    /*
    
    The important thing to note about this code is that although the logical expression controlling it is false, which 
    means that the loop will never repeat, the message Hello will be printed once, since the printing takes place 
    before the logical expression is tested.    

    A do-while construction is useful when you want to create code that continuously fetches data until a(n) (in)valid 
    value is entered.
    
    */
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Hello");
            } while (false);
        }
    }
}