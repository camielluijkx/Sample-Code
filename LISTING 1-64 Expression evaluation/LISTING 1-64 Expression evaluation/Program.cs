using System;

namespace LISTING_1_64_Expression_evaluation
{
    /*
    
    C# expressions are comprised of operatrs and operands. Operators specify the action to be performed, and er either 
    literal values or variables. An operator can work on one operand, and such operands are called unary or monadic.

    Monadic operators are either prefix (given before the operand) or postfix (given after the operand). Alternatively,
    an operand can work on two (binary), or in the case of the conditional operator ?: three ternary operands.

    The context of the use of an operator determines the actual behavior that the operator will exhibit. The use of an 
    incorrect context will be detected by the compiler and cause a compilation error.

    Each operator has a priority or precedence that determines when it is performed during expression evaluation. This
    precedence can be overridden by the use of parenthesis; elements enclosed in parenthesis are evaluated first. 
    
    Operators also have associability, which gives the order in which they are evaluated if a number of them appear 
    together.

    */
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0; // create i and set to 0

            // Monadic operators - one operand
            i++; // monadic ++ operator increment - i now 1
            i--; // monadic -- operator decrement - i now 0

            // Postfix monadic operator - peform after value given
            Console.WriteLine(i++); // writes 0 and sets i to 1
            // Prefix monadic operator - perform before value given
            Console.WriteLine(++i); // writes 2 and sets i to 2

            // Binary operators - two operands
            i = 1 + 1; // sets i to 2 
            i = 1 + 2 * 3; // sets i to 7 because * performed first
            i = (1 + 2) * 3; // sets i to 9 because + peformed first

            string str = "World!";

            str = "Hello " + str; // + performs string addition

            // ternary operators - three operands
            i = true ? 0 : 1; // sets i to 0 because condition is true

            Console.ReadKey();
        }
    }
}