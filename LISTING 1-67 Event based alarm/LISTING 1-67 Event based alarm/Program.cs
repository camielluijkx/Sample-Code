using System;

namespace LISTING_1_67_Event_based_alarm
{
    /*
    
    C# provides an event construction that allows a delegate to be specified as an event. The keyword event is added
    before the definition of the delegate. The member OnAlarmRaised is now created as a data field instead of a 
    property (OnAlarmRaised no longer has get or set behavior). It is now not possible for code external to the Alarm
    class to assign values to OnAlarmRaised, and the OnAlarmRaised delegate can only be called from within the class
    where it is declared. Adding the event keyword turns a deleaget into a properly useful event.

    */
    class Alarm
    {
        // Delegate for the alarm event
        public event Action OnAlarmRaised = delegate { };

        // Called to raise an alarm
        public void RaiseAlarm()
        {
            OnAlarmRaised();
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

            alarm.RaiseAlarm();

            // Connect the two listener methods
            alarm.OnAlarmRaised += AlarmListener1;
            alarm.OnAlarmRaised += AlarmListener2;

            alarm.RaiseAlarm();

            Console.WriteLine("Alarm raised.");
            Console.ReadKey();
        }
    }
}