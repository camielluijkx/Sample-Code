using System;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_17_Attached_child_tasks
{
    class Program
    {
        public static void DoChild(object state)
        {
            Console.WriteLine("Child {0} starting", state);
            Thread.Sleep(2000);
            Console.WriteLine("Child {0} finished", state);
        }

        static void Main(string[] args)
        {
            var parent = Task.Factory.StartNew(() => {
                Console.WriteLine("Parent starts");
                for (int i = 0; i < 10; i++)
                {
                    int taskNo = i;

                    // Code running inside a parent Task can create other tasks, but these "child" tasks will execute 
                    // indepently of the parent in which they were created.
                    // Such tasks are called detached child tasks or detached nested tasks.
                    // A parent task can create child tasks with a task creation option that specifies that the child 
                    // task is attached to the parent.
                    // The parent task will not complete until all of the attached child tasks have completed.
                    Task.Factory.StartNew(
                        (x) => DoChild(x),  // lambda function
                        taskNo, // state object
                        TaskCreationOptions.AttachedToParent); // DenyChildAttach is used when using Task.Run

                    // https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.taskcreationoptions?view=netframework-4.7.2
                }
            });

            parent.Wait(); // will wait for all the attached children to complete

            Console.WriteLine("Parent finished. Press a key to end.");
            Console.ReadKey();
        }
    }
}