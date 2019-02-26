using System;
using System.Threading;

namespace LISTING_1_20_Threads_and_lambda_expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // It is possible to start a thread using a lambda expression to specify the action of the thread.
            Thread thread = new Thread(() =>
            {
                Console.WriteLine("Hello from the thread");
                Thread.Sleep(1000);
            });
            thread.Start();

            Console.WriteLine("Press a key to end.");
            Console.ReadKey();

            /*
             
            Press a key to end.
            Hello from the thread

            Thread running inside the Main method calls Start to start the new thread.
            Before the new thread has started running, the thread running inside the Main method reaches the writeline 
            method on line 18.
            After that the background thread gets cibtrol and reaches the writeline on line 13.

            */
        }
    }
}
