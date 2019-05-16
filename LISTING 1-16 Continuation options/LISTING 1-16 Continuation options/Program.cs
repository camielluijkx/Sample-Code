using System;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_16_Continuation_options
{
    class Program
    {
        public static void HelloTask()
        {
            Thread.Sleep(1000);
            throw new Exception("Fail");
            Console.WriteLine("Hello");
        }

        public static void WorldTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("World");
        }

        public static void ExceptionTask()
        {
            Console.WriteLine("Exception thrown");
        }

        static void Main(string[] args)
        {
            Task task = Task.Run(() => HelloTask());

            // The ContinueWith method has an overload that you can use to specify when a given continuation task can
            // run (TaskContinuationOptions).
            task.ContinueWith((prevTask) => WorldTask(), TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith((prevTask) => ExceptionTask(), TaskContinuationOptions.OnlyOnFaulted);

            // https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.taskcontinuationoptions?view=netframework-4.7.2

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}