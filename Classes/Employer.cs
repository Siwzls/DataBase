using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    class Employer : Person
    {
        enum positionsAtWork { 
            Director = 0,
            Manager = 1,
            Cook = 2,
            Waiter = 3,
            Cleaner = 4
        }
    }
}
