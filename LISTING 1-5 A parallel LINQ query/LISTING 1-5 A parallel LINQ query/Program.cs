using System;
using System.Linq;

namespace LISTING_1_5_A_parallel_LINQ_query
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

            // The AsParallel method examines the query to determine if using a parallel version would speed it up.
            // The query is broken down into a number of processes and each is run concurrently when it is decided that 
            // executing elements of the query in parallel would improve performance.
            // The query is not executed in parallel if the AsParallel method couldn't decide whether parallelization 
            // would improve performance.
            // A non parallel query produces output data that has the same order as the input data.
            // A parallel query, however, may process data in a different order from the input data.

            Console.WriteLine("non parallel query:");
            var resultS = from person in people
                          where person.City == "Seattle"
                          //orderby person.Name
                          select person;

            foreach (var person in resultS)
                Console.WriteLine(person.Name);

            Console.WriteLine("parallel query:");
            var resultP = from person in people.AsParallel()
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