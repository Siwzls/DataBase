using System;

namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            Building build = new Building(2);
            Person guest = new Guests("Rihards", "Fabriks", 18, 2);

            guest.Info();

            Console.WriteLine(build.floorCount);
            Console.ReadKey();
        }
    }
}
