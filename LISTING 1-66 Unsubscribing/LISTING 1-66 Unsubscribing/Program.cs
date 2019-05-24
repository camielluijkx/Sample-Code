using System;

namespace LISTING_1_66_Unsubscribing
{
    /*
    
    The -= method is used to unsubscribe from events.
    
    If the same subscriber is added more then once to the same publisher, it will be called a corresponding number of 
    times when the event occurs.

    */
    class Alarm
    {
        // Delegate for the alarm event
        public Action OnAlarmRaised { get; set; }

        // Called to raise an alarm
        public void RaiseAlarm()
        {
            // Only raise the alarm if someone has subscribed. 
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
            alarm.OnAlarmRaised += AlarmListener1;
            alarm.OnAlarmRaised += AlarmListener2;

            alarm.RaiseAlarm();
            Console.WriteLine("Alarm raised.");

            alarm.OnAlarmRaised -= AlarmListener1;
            alarm.OnAlarmRaised -= AlarmListener1;

            alarm.RaiseAlarm();
            Console.WriteLine("Alarm raised.");

            Console.ReadKey();
        }
    }
}