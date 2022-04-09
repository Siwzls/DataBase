using System;
using System.IO;
using System.Xml;
namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            DataClass person = new Person("people.xml");
            bool isWorking = true;
            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine("Hello, choose option:");
                Console.WriteLine("1. Show Data");
                Console.WriteLine("2. Add Data");
                Console.WriteLine("3. Save Data");
                Console.WriteLine("4. Delete Data");
                Console.WriteLine("5. Exit");
                Console.WriteLine("=============");
                Console.WriteLine("Enter your option: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        person.ShowData("Person");
                        break;
                    case "2":
                        Console.Clear();
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        person.SaveData();
                        person.ShowData("Person");
                        break;
                    case "4":
                        Console.Clear();
                        break;
                    case "5":
                        isWorking = !isWorking;
                        break;
                    default:
                        isWorking = !isWorking;
                        break;
                }
            }
        }
    }
}