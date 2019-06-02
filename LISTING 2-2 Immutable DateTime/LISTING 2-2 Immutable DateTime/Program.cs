using System;

namespace LISTING_2_2_Immutable_DateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a DateTime for today
            DateTime date = DateTime.Now;

            // Move the date on to tomorrow
            date = date.AddDays(1);

            Console.WriteLine(date);

            Console.ReadKey();
        }
    }
}