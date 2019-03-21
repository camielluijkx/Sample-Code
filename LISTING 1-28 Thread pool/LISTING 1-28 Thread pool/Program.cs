using System;
using System.Threading;

namespace LISTING_1_28_Thread_pool
{
    /*
     
    Threads, like everything else in C#, are managed as objects.

    If an application creates a large number of threads, each of these will require an object to be created and then
    destroyed when the thread completes.

    A thread pool stores a collection of reusable thread objects.

    Rather than creating a new Thread instance, an application can instead request that a process execute on a thread
    from the thread pool.

    When the thread completes, the thread is returned to the pool for use by another process.

    The ThreadPool provides a method QueueUserWOrkItem, which allocates a thread to run the supplied item of work.

    The item of work is supplied as a WaitCallBack delegate.

    There are two versions of this delegate:

        • The version used below accepts a state object that can be used to provide state information to the thread to
          be started.
        • The other version of WaitCallback does not accept state information.

    The ThreadPool restricts the number of active threads and mintains a queue of threads waiting to execute.

    A program that creates a large number of individual threads can easily overwhelm a device.

    This does not happen if a ThreadPool is used, when the extra threads are placed in the queue.

    There are some situations when using the ThreadPool is not an good idea:
    
        • If you create a large number of threads that may be idle for a very long time, this may block the ThreadPool, 
          because the ThreadPool only contains a fiinite number of threads.
        • You cannot manage the priority of threads in the ThreadPool.
        • Threads in the ThreadPool have background priority. You cannot obtain a thread with foreground priority from 
          the ThreadPool.
        • Local state variables are not cleared when a ThreadPool thread is reused. They therefore should not be used.

    */
    class Program
    {
        [ThreadStatic]
        static int LocalState;

        static void DoWork(object state)
        {
            Console.WriteLine($"Doing work: {state}.");
            LocalState = LocalState + 1; 
            Console.WriteLine($"Local state: {LocalState}.");
            Thread.Sleep(500);
            Console.WriteLine($"Work finished: {state}.");
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 50; i++)
            {
                int stateNumber = i;
                ThreadPool.QueueUserWorkItem(state => DoWork(stateNumber));
            }
            Console.ReadKey();
        }
    }
}