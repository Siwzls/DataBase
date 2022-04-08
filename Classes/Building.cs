using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    class Building : DataClass
    {
        public int floorCount;

        public Building(string filename, int floorCount)
        {
            this.filename = filename;
            this.floorCount = floorCount;
        }
    }
}
