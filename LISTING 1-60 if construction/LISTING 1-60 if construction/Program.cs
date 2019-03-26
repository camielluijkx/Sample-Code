using System;

namespace LISTING_1_60_if_construction
{
    /*
    
    An if construction allows the use of a logical expression to control the execution of a statement or block of code.
    A logicla expression is one that evaluates to the Boolean value true or false. When the logical statement is true, 
    the statement is obeyed. An if construction can have an else statement that contains code that is to be executed
    when the Boolean value evaluates to false.

    The else statement of an if construction is optional. It is possible to "nest" if constructions inside one another.

    Not all if constructions are required to have else statements. There is never any confusion about which if 
    condition a given else binds to, since it is always the "nearest" one.

    */
    class Program
    {
        static void Main(string[] args)
        {
            if (true)
            {
                Console.WriteLine("This statement is always performed.");
            }
            else
            {
                Console.WriteLine("This statement is never performed.");
            }

            if (true)
            {
                Console.WriteLine("This statement is always performed.");
                if (true)
                {
                    Console.WriteLine("This statement is always performed.");
                }
                else
                {
                    Console.WriteLine("This statement is never performed.");
                }
            }

            if (true)
            {
                Console.WriteLine("This statement is always performed.");
                if (true)
                {
                    Console.WriteLine("This statement is always performed.");
                }
            }
            else
            {
                Console.WriteLine("This statement is never performed.");
            }
        }
    }
}