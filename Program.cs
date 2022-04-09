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
                Console.WriteLine("3. Delete Data");
                Console.WriteLine("4. Exit");
                Console.WriteLine("=============");
                Console.WriteLine("Enter your option: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Beep();
                        Console.Clear();
                        person.ShowData("Person");
                        break;
                    case "2":
                        Console.Beep();
                        Console.Clear();
                        person.AddData();
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Beep();
                        Console.Clear();
                        person.DeleteData(0);
                        break;
                    case "4":
                        Console.Beep();
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