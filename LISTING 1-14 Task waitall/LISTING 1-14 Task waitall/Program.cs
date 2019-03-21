using System;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_14_Task_waitall
{
    class Program
    {
        public static void DoWork(int i)
        {
            Console.WriteLine($"Task {i} starting.");
            Thread.Sleep(2000);
            Console.WriteLine($"Task {i} finished.");
        }

        static void Main(string[] args)
        {
            Task[] Tasks = new Task[10];

            for (int i = 0; i < 10; i++)
            {
                // make a local copy of loop counter so that the correct task number is passed into the lambda function
                int taskNum = i;
                Tasks[i] = Task.Run(() => DoWork(taskNum));

                // all of the tasks would have number 10, which is the value of the limit of the loop
                //Tasks[i] = Task.Run(() => DoWork(i));  
            }

            /* 
             
            The Task.WaitAll method can be used to pause a program until a number of tasks have completed.
            
            The Task.WaitAny method can be used to pause a program until any of the tasks have completed.

            */
            Task.WaitAll(Tasks);
            //Task.WaitAny(Tasks);

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}