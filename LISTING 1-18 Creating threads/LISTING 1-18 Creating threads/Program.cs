using System;
using System.Threading;

namespace LISTING_1_18_Creating_threads
{
    class Program
    {
        static void ThreadHello()
        {
            Console.WriteLine("Hello from the thread");
            Thread.Sleep(2000);
        }

        static void Main(string[] args)
        {
            // task vs Thread
            // A Task object represents an item of work to be performed.
            // A Thread object represents a process running within the Operating System.

            // Foreground vs Background
            // Threads are created as foreground processes (although they can be set to run in the background).
            // The operating system will run a foreground process to completion, which means that an application will
            // not terminate while it contains an active foreground thread.
            // A foreground process that contains an infinite loop will execute forever, or until it throws an uncaught
            // exception or when the operating system terminates it.
            // Tasks are created as background processes.
            // Tasks can be terminated before they complete if all the foreground threads in an application complete.

            // Priority
            // Threads have a priority property that can be changed during the lifetime of a thread.
            // It is not possible to set the priority of a Task.
            // This gives a thread a higher priority request so a greater portion of processor time is allocated.

            // Share Result
            // A thread cannot deliver a result to another thread.
            // Threads must communicate by using shared variables, which can introduce synchronization issues.

            // Continuation
            // It is not possible to create a continuation on a thread.
            // Instead, threads provide a method called a join, which allows one thread to pause until another 
            // completes.

            // Aggregate Exceptions
            // It is not possible to aggregate exceptions over a number of threads.
            // An exception thrown inside a thread must be caught and dealt with by the code in that thread.
            // Tasks provide exception aggregation, but threads don't.

            Thread thread = new Thread(ThreadHello);
            thread.Start();

            Console.WriteLine("Press a key to end.");
            Console.ReadKey();

            /*
             
            Hello from the thread
            Press a key to end.

            OR

            Press a key to end.
            Hello from the thread

            */
        }
    }
}
