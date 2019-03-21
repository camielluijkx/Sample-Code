using System;
using System.Threading;

namespace LISTING_1_27_Thread_context
{
    class Program
    {
        /*
        
        A Thread instance exposes a range of context information, and some items can be read and others read and set.
        
        The information available includes the name of the thread, (if any) priority of the thread, whether it is
        foreground or background, the threads culture and the security context of the thread.
        
        */
        static void DisplayThread(Thread t)
        {
            Console.WriteLine($"Name: {t.Name}.");
            Console.WriteLine($"Culture: {t.CurrentCulture}.");
            Console.WriteLine($"Priority: {t.Priority}.");
            Console.WriteLine($"Context: {t.ExecutionContext}.");
            Console.WriteLine($"IsBackground?: {t.IsBackground}.");
            Console.WriteLine($"IsPool?: {t.IsThreadPoolThread}.");

        }
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main method";
            DisplayThread(Thread.CurrentThread);
            Console.ReadKey();
        }
    }
}