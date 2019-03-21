using System;
using System.Threading;

namespace LISTING_1_20_Threads_and_lambda_expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            
            It is possible to start a thread using a lambda expression to specify the action of the thread:

                • The thread running inside the Main method calls Start to start the new thread.
                • Before the new thread has started running, the thread running inside the Main method reaches the 
                  writeline method and displays "Press a key to end.".
                • After that the background thread gets control and prints "Hello from the thread.".

            */
            Thread thread = new Thread(() =>
            {
                Console.WriteLine("Hello from the thread.");
                Thread.Sleep(1000);
            });
            thread.Start();

            Console.WriteLine("Press a key to end.");
            Console.ReadKey();

            /*
             
            Press a key to end.
            Hello from the thread.

            */
        }
    }
}