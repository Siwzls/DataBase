using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    class Person : DataClass
    {
        protected string name;
        protected string lastName;
        protected int age;

        public Person(string filename)
        {
            this.filename = filename;
        }

        public void Info()
        {
            Console.WriteLine($"Person name: {name} {lastName}");
            Console.WriteLine($"Person age: {age}");
        }
    }
}
