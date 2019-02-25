using System;
using System.Linq;

namespace LISTING_1_10_Exceptions_in_PLINQ
{
    class Program
    {
        public static bool CheckCity(string city)
        {
            if (city == "")
                throw new ArgumentException(city);
            return city == "Seattle";
        }

        public static bool CheckCity(string name, string city)
        {
            if (city == "")
            {
                Console.WriteLine($"no city for {name}");
                throw new ArgumentException(city);
            }
            return city == "Seattle";
        }

        class Person
        {
            public string Name { get; set; }
            public string City { get; set; }
        }

        static void Main(string[] args)
        {
            Person[] people = new Person[] {
                //new Person { Name = "Alan", City = "Hull" },
                new Person { Name = "Alan", City = "" },
                new Person { Name = "Beryl", City = "Seattle" },
                new Person { Name = "Charles", City = "London" },
                new Person { Name = "David", City = "Seattle" },
                new Person { Name = "Eddy", City = "" },
                new Person { Name = "Fred", City = "" },
                new Person { Name = "Gordon", City = "Hull" },
                new Person { Name = "Henry", City = "Seattle" },
                new Person { Name = "Isaac", City = "Seattle" },
                new Person { Name = "James", City = "London" }};

            try
            {
                // An AggregateException is thrown when all queries are completed if any query generates an exception.
                var result = from person in
                    people.AsParallel()
                             //where CheckCity(person.City)
                             where CheckCity(person.Name, person.City)
                             select person;
                result.ForAll(person => Console.WriteLine(person.Name));
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.InnerExceptions.Count + " exception(s)."); // might be > 1
            }

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
