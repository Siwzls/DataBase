using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    class Guests : Person
    {
        int hotelRoomID;

        public Guests(string filename, int id, string name,
        string lastName, int age, int hotelRoomID) : base(filename)
        {
            this.id = id;
            this.name = name;
            this.lastName = lastName;
            this.age = age;
            this.hotelRoomID = hotelRoomID;
        }
    }
}
