using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DataBase
{
    class Guests : Person
    {
        public Guests(string filename) : base(filename)
        {

        }
        public Guests(string filename, string name, string lastName, int age) 
        : base(filename, name, lastName, age)
        {
        }
    }
}
