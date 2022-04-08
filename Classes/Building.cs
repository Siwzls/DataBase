using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    class Building : DataClass
    {
        public int floorCount;

        public Building(int floorCount)
        {
            this.floorCount = floorCount;
        }
    }
}
