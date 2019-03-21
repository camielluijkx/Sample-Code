using System;
using System.Threading;

namespace LISTING_1_21_ParameterizedThreadStart
{
    class Program
    {
        static void WorkOnData(object data)
        {
            Console.WriteLine($"Working on: {data}.");
            Thread.Sleep(1000);
        }
        static void Main(string[] args)
        {
            /*
            
            A program can pass data into a thread when it is created by using the ParameterizedThreadStart delegate:
            
                • This specifies the thread method as one that accepts a single object parameter.
                • The object to be passed into the thread is then placed in the Start method.
            
            */
            ParameterizedThreadStart ps = new ParameterizedThreadStart(WorkOnData);
            Thread thread = new Thread(ps);
            thread.Start(99);

            Console.WriteLine("Press a key to end.");
            Console.ReadKey();

            /*
             
            Press a key to end.
            Working on: 99.

            */
        }
    }
}