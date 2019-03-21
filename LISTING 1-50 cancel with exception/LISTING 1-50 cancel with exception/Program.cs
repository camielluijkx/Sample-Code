using System;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_50_cancel_with_exception
{
    /*
    
    A Task can indicate that is has been cancelled by raising an exception. This can be useful if a task is started in
    one place and monitored in another. The Clock method below ticks 20 times and then exits. It is supplied with a 
    CancellationToken reference as a parameter, which is tested each time around the tick loop. If the task is 
    cancelled, it throws an exception.
    
    */
    class Program
    {
        static void Clock(CancellationToken cancellationToken)
        {
            int tickCount = 0;

            while (!cancellationToken.IsCancellationRequested && tickCount < 20)
            {
                tickCount++;
                Console.WriteLine("Tick");
                Thread.Sleep(500);
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        static void Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            Task clock = Task.Run(() => Clock(cancellationTokenSource.Token));

            Console.WriteLine("Press any key to stop the clock.");

            Console.ReadKey();

            if (clock.IsCompleted)
            {
                Console.WriteLine("Clock task completed.");
            }
            else
            {
                try
                {
                    cancellationTokenSource.Cancel();
                    clock.Wait();
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine("Clock stopped: {0}.", ex.InnerExceptions[0].ToString());
                }
            }
            Console.ReadKey();

            /*

            Press any key to stop the clock.
            Tick
            ...
            Tick
            Clock stopped: System.OperationCanceledException: The operation was canceled.
               at System.Threading.CancellationToken.ThrowOperationCanceledException()
               at System.Threading.CancellationToken.ThrowIfCancellationRequested()
               at LISTING_1_50_cancel_with_exception.Program.Clock(CancellationToken cancellationToken) in C:\Workspace\MicrosoftLearning\Sample-Code\LISTING 1-50 cancel with exception\LISTING 1-50 cancel with exception\Program.cs:line 20
               at LISTING_1_50_cancel_with_exception.Program.<>c__DisplayClass1_0.<Main>b__0() in C:\Workspace\MicrosoftLearning\Sample-Code\LISTING 1-50 cancel with exception\LISTING 1-50 cancel with exception\Program.cs:line 27
               at System.Threading.Tasks.Task.InnerInvoke()
               at System.Threading.Tasks.Task.Execute().

            OR

            Press any key to stop the clock.
            Tick
            Tick
            Tick
            Tick
            Tick
            Tick
            Tick
            Tick
            Tick
            Tick
            Tick
            Tick
            Tick
            Tick
            Tick
            Tick
            Tick
            Tick
            Tick
            Tick
            Clock task completed.

            */
        }
    }
}
