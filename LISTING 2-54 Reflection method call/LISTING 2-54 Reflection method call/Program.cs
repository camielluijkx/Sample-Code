using System;
using System.Reflection;

namespace LISTING_2_54_Reflection_method_call
{
    class Person
    {
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Type type;

            Person p = new Person();
            type = p.GetType();

            MethodInfo setMethod = type.GetMethod("set_Name");
            setMethod.Invoke(p, new object [] { "Fred" });

            Console.WriteLine(p.Name);

            Console.ReadKey();
        }
    }
}