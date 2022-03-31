using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    class Person
    {
        protected string name;
        protected string lastName;
        protected int age;

        public void Info()
        {
            Console.WriteLine($"Person name: {name} {lastName}");
            Console.WriteLine($"Person age: {age}");
        }
    }
}
