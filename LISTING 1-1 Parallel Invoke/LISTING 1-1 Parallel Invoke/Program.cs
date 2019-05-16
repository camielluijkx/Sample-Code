using System;
using System.Threading;
using System.Threading.Tasks;

namespace Listing_1._1Parallel_Invoke
{
    class Program
    {
        static void Task1()
        {
            Console.WriteLine("Task 1 starting");
            //Thread.Sleep(2000);
            Thread.Sleep(1000);
            Console.WriteLine("Task 1 ending");
        }

        static void Task2()
        {
            Console.WriteLine("Task 2 starting");
            //Thread.Sleep(2000);
            Thread.Sleep(1000);
            Console.WriteLine("Task 2 ending");
        }

        static void Main(string[] args)
        {
            // The Task.Parallel class can be found in the System.Threading.Tasks namespace.
            // The Parallel.Invoke method accepts a number of Action delegates and creates a Task for each of them.
            // An action delegate is an encapsulation of a method that accepts no parameters and does not return a 
            // result. 
            // An action delegate can be replaced with a lambda expression.
            // Note that you have no control over the order in which the tasks are started or which processor they are 
            // assigned to (e.g. Task1 might finish before Task2 and vice versa).

            Action action1a = () => Task1();
            Action action2a = () => Task2();
            //Parallel.Invoke(action1a, action2a);

            Action action1b = new Action(() => Task1());
            Action action2b = new Action(() => Task2());
            //Parallel.Invoke(action1b, action2b);

            Parallel.Invoke(() => Task1(), () => Task2());

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}