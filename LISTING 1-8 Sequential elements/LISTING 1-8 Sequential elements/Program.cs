using System;
using System.Linq;

namespace LISTING_1_8_Sequential_elements
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

            // The AsSequential method can be used to identify parts of a query that must be executed sequentially.
            // AsSequential executes the query in order whereas AsOrdered returns a sorted result but but does not
            // necessarily run the query in order.

            Console.WriteLine("non parallel query:");
            var resultS = (from person in people
                          where person.City == "Seattle"
                          //orderby person.Name
                          select person).Take(3);

            foreach (var person in resultS)
                Console.WriteLine(person.Name);

            Console.WriteLine("parallel query:");
            var resultP = (from person in people.AsParallel()
                          where person.City == "Seattle"
                          //orderby person.Name
                          select person).AsSequential().Take(3);

            foreach (var person in resultP)
                Console.WriteLine(person.Name);

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}