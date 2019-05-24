using System;

namespace LISTING_1_65_Null_conditional
{
    /*
    
    The null conditional operator ".?" means, "only access this member of the class if the reference is not null".

    A delegate exposes an Invoke method to invoke the methods bound to the delegate.

    */
    class Alarm
    {
        // Delegate for the alarm event
        public Action OnAlarmRaised { get; set; }

        // Called to raise an alarm
        public void RaiseAlarm()
        {
            // Only raise the alarm if someone has subscribed
            OnAlarmRaised?.Invoke();
        }
    }

    class Program
    {
        // Method that must run when the alarm is raised
        static void AlarmListener1()
        {
            Console.WriteLine("Alarm listener 1 called.");
        }

        // Method that must run when the alarm is raised
        static void AlarmListener2()
        {
            Console.WriteLine("Alarm listener 2 called.");
        }

        static void Main(string[] args)
        {
            // Create a new alarm
            Alarm alarm = new Alarm();

            // Connect the two listener methods
            alarm.OnAlarmRaised += AlarmListener1;
            alarm.OnAlarmRaised += AlarmListener2;

            alarm.RaiseAlarm();
            Console.WriteLine("Alarm raised.");
            Console.ReadKey();

            // coalesce operator
            int? x = null;

            // Set y to the value of x if x is NOT null; otherwise,
            // if x == null, set y to -1.
            int y = x ?? -1;

            Console.ReadKey();
        }
    }
}