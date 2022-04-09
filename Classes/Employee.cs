using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    class Employee : Person
    {
        enum positionsAtWork
        {
            Director = 0,
            Manager = 1,
            Cook = 2,
            Waiter = 3,
            Cleaner = 4
        }
        public Employee(string filename, string name, string lastName, int age) 
            : base(filename, name, lastName, age)
        {

        }
    }
}
