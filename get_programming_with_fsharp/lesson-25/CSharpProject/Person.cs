using System;

namespace CSharpProject
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void PrintName()
        {
            System.Console.Out.WriteLine($"My Name is {Name}");
        }



    }
}
