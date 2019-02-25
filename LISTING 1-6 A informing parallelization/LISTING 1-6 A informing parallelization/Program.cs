using System;
using System.Linq;

namespace LISTING_1_6_Informing_parallelization
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
            Person[] people = new Person[] {
                new Person { Name = "Alan", City = "Hull" },
                new Person { Name = "Beryl", City = "Seattle" },
                new Person { Name = "Charles", City = "London" },
                new Person { Name = "David", City = "Seattle" },
                new Person { Name = "Eddy", City = "Paris" },
                new Person { Name = "Fred", City = "Berlin" },
                new Person { Name = "Gordon", City = "Hull" },
                new Person { Name = "Henry", City = "Seattle" },
                new Person { Name = "Isaac", City = "Seattle" },
                new Person { Name = "James", City = "London" }};

            // Programs can use other method calls to further inform the parallelization process.
            // WithExecutionMode(ParallelExecutionMode.ForceParallelism) requests the query is run in parallel whether 
            // performance is improved or not.
            // WithDegreeOfParallelism(x) requests the query is being executed on a maximum of x processors.
            // A non parallel query produces output data that has the same order as the input data.
            // A parallel query, however, may process data in a different order from the input data.
            var result = from person in people.AsParallel()
                         .WithDegreeOfParallelism(4)
                         .WithExecutionMode(ParallelExecutionMode.ForceParallelism) // or Default
                         where person.City == "Seattle"
                         select person;

            foreach (var person in result)
                Console.WriteLine(person.Name);

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
