using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    class Guests : Person
    {
        int hotelRoomID;

        public Guests(string name, string lastName, int age, int hotelRoomID)
        {
            this.name = name;
            this.lastName = lastName;
            this.age = age;
            this.hotelRoomID = hotelRoomID;
        }
    }
}
