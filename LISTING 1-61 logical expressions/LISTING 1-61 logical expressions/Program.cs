using System;

namespace LISTING_1_61_logical_expressions
{
    /*
    
    The & and | operators have conditional versions: && and ||. These are only evaluated until it can be determined 
    whether the result of the expressions is true or false. In the case of &&, if the first operand is false, the 
    program will not evaluate the second operand since it is already established that the result of the expression is 
    false. In the case of ||, if the first operand is true the second operand will not be evaluated as it is already 
    established that the result of the expression is true. This is also referred to as short circuiting the evaluation
    of the expression.
        
    */
    class Program
    {
        static int mOne()
        {
            Console.WriteLine("mOne called");
            return 1;
        }

        static int mTwo()
        {
            Console.WriteLine("mTwo called");
            return 1;
        }

        static void Main(string[] args)
        {
            if (mOne() == 2 && mTwo() == 1)
            {
                Console.WriteLine("Hello cand");
            }

            if (mOne() == 1 || mTwo() == 2)
            {
                Console.WriteLine("Hello cor");
            }

            if (mOne() == 1 ^ mTwo() == 2)
            {
                Console.WriteLine("Hello xor");
            }

            Console.ReadKey();
        }
    }
}