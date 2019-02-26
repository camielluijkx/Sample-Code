using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_22_thread_lambda_parameters
{
    class Program
    {
        static void WorkOnData(object data)
        {
            Console.WriteLine("Working on: {0}", data);
            Thread.Sleep(1000);
        }

        static void Main(string[] args)
        {
            // Another way to pass data into a thread is to specify the behavior of the thread as a lambda expression
            // that accepts a parameter.
            // The parameter to the lambda expression is the data to be passed into the thread.
            Thread thread = new Thread((data) =>
            {
                WorkOnData(data);
            });
            thread.Start(99);

            // Note that the data to be passed into the thread is always passed as an object reference.
            // This means that there is no way to be sure at compile time that thread initialization is being performed
            // with a particular type of data.
            //thread.Start("99"); 

            Console.WriteLine("Press a key to end.");
            Console.ReadKey();

            /*
             
            Press a key to end.
            Working on: 99

            */
        }
    }
}
