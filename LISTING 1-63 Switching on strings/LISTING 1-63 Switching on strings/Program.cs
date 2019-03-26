using System;

namespace LISTING_1_63_Switching_on_strings
{
    /*
    
    In C# it is not permissible for a program to "fall through" from the end of one case clause into another. Each 
    clause must be explicitly ended with a break, a return, or by the program throwing an exception.  

    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter command: ");
            string commandName = Console.ReadLine().ToLower() ;

            switch (commandName)
            {
                case "save":
                case "s":
                    Console.WriteLine("Save command.");
                    break;
                case "load":
                case "l":
                    Console.WriteLine("Load command.");
                    break;
                case "exit":
                case "e":
                    Console.WriteLine("Exit command.");
                    break;
                default:
                    Console.WriteLine("Please enter save, load or exit.");
                    break;
            }
            Console.ReadKey();
        }
    }
}