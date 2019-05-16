using System;
using System.Threading;

namespace LISTING_1_27_ThreadLocal
{
    class Program
    {
        /*
        
        You can use the ThreadStatic attribute to specify that the given variable should be created for each thread.
        
        */
        [ThreadStatic]
        private static int x = 99; // initialization will not matter as it will be defaulted for each thread

        private static ThreadLocal<int> y = 
            new ThreadLocal<int>(() =>
            {
                return 99;
            });

        /* 
        
        If your program needs to initialize the local data for each thread you can use the ThreadLocal<T> class.
        
        When an instance of ThreadLocal is created it gives a delegate to the code that will initialize attributes of 
        threads.

        */
        public static ThreadLocal<Random> RandomGenerator =
            new ThreadLocal<Random>(() =>
            {
                return new Random(2);
            });

        static void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    //Console.WriteLine(x--); // 0..-4
                    //Console.WriteLine(y.Value--); // 99..95
                    Console.WriteLine("t1: {0}", RandomGenerator.Value.Next(10));
                    Thread.Sleep(500);
                }
            });

            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    //Console.WriteLine(x++); // 0..4
                    //Console.WriteLine(y.Value++); // 99..103
                    Console.WriteLine("t2: {0}", RandomGenerator.Value.Next(10));
                    Thread.Sleep(500);
                }
            });

            t1.Start();
            t2.Start();

            Console.ReadKey();

            /*
            
            t2: 7
            t1: 7
            t2: 4
            t1: 4
            t2: 1
            t1: 1
            t2: 9
            t1: 9
            t2: 1
            t1: 1
           
            */
        }
    }
}