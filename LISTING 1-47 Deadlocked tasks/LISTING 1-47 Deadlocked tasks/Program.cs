using System;
using System.Threading.Tasks;

namespace LISTING_1_47_Deadlocked_tasks
{
    /*
    
    An incorrect use of the lock statement can introduce deadlocks into your applications.
        
    */
    class Program
    {
        static object lock1 = new object();
        static object lock2 = new object();

        static void Method1()
        {
            lock (lock1)
            {
                Console.WriteLine("Method 1 got lock 1.");
                Console.WriteLine("Method 1 waiting for lock 2.");
                lock (lock2)
                {
                    Console.WriteLine("Method 1 got lock 2.");
                }
                Console.WriteLine("Method 1 released lock 2.");
            }
            Console.WriteLine("Method 1 released lock 1.");
        }

        static void Method2()
        {
            lock (lock2)
            {
                Console.WriteLine("Method 2 got lock 2.");
                Console.WriteLine("Method 2 waiting for lock 1.");
                lock (lock1)
                {
                    Console.WriteLine("Method 2 got lock 1.");
                }
                Console.WriteLine("Method 2 released lock 1.");
            }
            Console.WriteLine("Method 2 released lock 2.");
        }

        static void Main(string[] args)
        {
            Task t1 = Task.Run(() => Method1());
            Task t2 = Task.Run(() => Method2());
            Console.WriteLine("Waiting for Task 2.");
            t2.Wait(); // potential deadlock 

            Console.WriteLine("Tasks complete. Press any key to exit.");
            Console.ReadKey();

            /*
            
            Waiting for Task 2.
            Method 2 got lock 2.
            Method 2 waiting for lock 1.
            Method 1 got lock 1.
            Method 1 waiting for lock 2.

            */
        }
    }
}