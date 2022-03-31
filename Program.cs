using System;

namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            Building build = new Building(2);

            Console.WriteLine(build.floorCount);
            Console.ReadKey();
        }
    }
}
