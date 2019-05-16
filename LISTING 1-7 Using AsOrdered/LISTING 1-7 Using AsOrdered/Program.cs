using System;
using System.Linq;

namespace LISTING_1_7_Using_AsOrdered
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }

            public string City { get; set; }
        }

        static void Main(string[] args)
        {
            Person[] people = new Person[]
            {
                new Person { Name = "Alan", City = "Hull" },
                new Person { Name = "Henry", City = "Seattle" },
                new Person { Name = "Charles", City = "London" },
                new Person { Name = "Isaac", City = "Seattle" },
                new Person { Name = "Gordon", City = "Hull" },
                new Person { Name = "David", City = "Seattle" },
                new Person { Name = "Eddy", City = "Paris" },
                new Person { Name = "Fred", City = "Berlin" },
                new Person { Name = "Beryl", City = "Seattle" },
                new Person { Name = "James", City = "London" }
            };

            // The AsOrdered method can be used to request the query to preserve the order of the original data.
            // The AsOrdered method doesn't prevent the parallelization of the query, instead it organizes the output 
            // so that it is in the same order as the original data which can slow down the query.

            Console.WriteLine("non parallel query:");
            var resultS = from person in people
                          where person.City == "Seattle"
                          //orderby person.Name
                          select person;

            foreach (var person in resultS)
                Console.WriteLine(person.Name);

            Console.WriteLine("parallel query:");
            var resultP = from person in people.AsParallel().AsOrdered()
                          where person.City == "Seattle"
                          //orderby person.Name
                          select person;

            foreach (var person in resultP)
                Console.WriteLine(person.Name);

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}