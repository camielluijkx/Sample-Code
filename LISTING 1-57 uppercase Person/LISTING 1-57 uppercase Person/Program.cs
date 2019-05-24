using System;

namespace LISTING_1_57_uppercase_Person
{
    /*
    
    If the foreach loop is working on a list of references to objects, the objects on the ends of those references can 
    be changed.

    The foreach construction can iterate through any object which implements the IEnumerable interface. These objects
    expose a method called GetIterator(). This method must return an object that implements the 
    System.Collections.IEnumerator interface. This interface exposes methods that the foreach construction can use to 
    get the next item from the enumerator and determine if there any more items in the collection. Many collection 
    classes, including listst and dictionaries, implement the IEnumerable interface.

    Note that the iteration can be implemented in a "lazy" way; the next item to be iterated only needs to be fetched
    when requested. The result of database queries can be returned as objects that implement the IEnumerable interface
    and then only fetch the actual data items when needed. It is important that the item being iterated is not changed
    during iteration, if the iterating code tried to remove items from the list it was iterating through this would 
    cause the program to throw an exception when it ran.
    
    */
    class Program
    {
        class Person
        {
            public string Name { get; set; }

            public Person(string name)
            {
                Name = name;
            }
        }

        static void Main(string[] args)
        {
            Person[] people = new Person[] 
            {
                new Person("Rob"), new Person("Mary"),
                new Person("David"), new Person("Jenny"),
                new Person("Chris"), new Person("Imogen")
            };

            foreach (Person person in people)
            {
                person.Name = person.Name.ToUpper();
            }

            foreach (Person person in people)
            {
                Console.WriteLine(person.Name);
            }

            Console.ReadKey();
        }
    }
}