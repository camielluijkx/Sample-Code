using System;

namespace LISTING_1_65_Publish_and_subscribe
{
    /*
     
    Subscribers bind to a publisher by using the += operator. The += operator is overloaded to apply between a delegate 
    and a behavior. It means "add this behavior to the ones for this delegate". The methods in a delegate are not 
    guaranteed to be called in the order that they were added to the delegate.
    
    Delegates added to a published event are are called on the same thread as the thread publishing the event. If a 
    delegate blocks this thread, the entirer publication mechanism is blocked. This means that a malicious or badly
    written subscriber has the ability to block the publications of events. This is addressed by the publisher starting
    an individual task to run each of the event subscribers. The delegate object in a publisher exposes a method 
    GetInvocationList which can be used to get a list of all the subscribers.
   
    */
    class Alarm
    {
        // Delegate for the alarm event
        public Action OnAlarmRaised { get; set; }

        // Called to raise an alarm
        public void RaiseAlarm()
        {
            // Only raise the alarm if someone has subscribed
            if (OnAlarmRaised != null)
            {
                OnAlarmRaised();
            }
        }
    }

    class Program
    {
        // Method that must run when the alarm is raised
        static void AlarmListener1()
        {
            Console.WriteLine("Alarm listener 1.");
        }

        // Method that must run when the alarm is raised
        static void AlarmListener2()
        {
            Console.WriteLine("Alarm listener 2.");
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
        }
    }
}