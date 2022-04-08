using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    class Guests : Person
    {
        public Guests(string filename) : base(filename)
        {

        }
        public Guests(string filename, int id, string name, string lastName, int age) 
        : base(filename, id, name, lastName, age)
        {
        }
    }
}
