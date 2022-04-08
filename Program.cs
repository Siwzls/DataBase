using System;
using System.IO;
using System.Xml;
namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("people.xml");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hello, choose option:");
                Console.WriteLine("1. Show data");
                Console.WriteLine("2. Get Id");
                Console.WriteLine("=============");
                Console.WriteLine("Enter your option: ");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.Clear();
                        person.ShowData("People");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(person.GetFreeId());
                        break;
                }
            }
        }
    }
}