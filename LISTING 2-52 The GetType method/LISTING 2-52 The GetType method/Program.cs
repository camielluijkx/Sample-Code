using System;

namespace LISTING_2_52_The_GetType_method
{
    [AttributeUsage(AttributeTargets.Class)]
    class ProgrammerAttribute : Attribute
    {
        private string programmerValue;

        public ProgrammerAttribute(string programmer)
        {
            programmerValue = programmer;
        }

        public string Programmer
        {
            get
            {
                return programmerValue;
            }
        }
    }

    [ProgrammerAttribute(programmer: "Fred")]
    class Person
    {
        // This would cause a compilation error as we 
        // are only allowed to apply this attribute to classes
        // [ProgrammerAttribute(programmer: "Fred")]
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Type type;

            Person p = new Person();
            type = p.GetType();
            Console.WriteLine("Person type: {0}", type.ToString());

            Console.ReadKey();
        }
    }
}