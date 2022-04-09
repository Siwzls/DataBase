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

        public Person(string filename){
            this.filename = filename;
        }
        public Person(string filename, string name, string lastName, int age)
        {
            this.filename = filename;
            this.name = name;
            this.lastName = lastName;
            this.age = age;
        }
        public void Info()
        {
            Console.WriteLine($"Person name: {name} {lastName}");
            Console.WriteLine($"Person age: {age}");
        }
    }
}
