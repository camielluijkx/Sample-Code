﻿using System;

namespace LISTING_1_79_The_finally_block
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter an integer: ");
                string numberText = Console.ReadLine();
                int result;
                result = int.Parse(numberText);
                Console.WriteLine("You entered {0}", result);
                int sum = 1 / result;
                Console.WriteLine("Sum is {0}", sum);
            }
            catch (NotFiniteNumberException nx)
            {
                Console.WriteLine("Invalid number");
            }
            catch (DivideByZeroException zx)
            {
                Console.WriteLine("Divide by zero");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected exception");
            }
            finally
            {
                Console.WriteLine("Thanks for using my program.");
            }

            Console.ReadKey();
        }
    }
}