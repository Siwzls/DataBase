using System;
using System.IO;
using System.Xml;
namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            DataClass data;
            bool isWorking = true;
            Console.WriteLine("Hello, choose option:");
            while (isWorking)
            {
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
                        Console.WriteLine("Ñhoose data:");
                        Console.WriteLine("1. People");
                        Console.WriteLine("2. Buildings");
                        Console.WriteLine("3. Hotel rooms");
                        switch (Console.ReadLine()) 
                        {         
                            case "1":
                                DataClass.ShowData("Persons", "people.xml");
                                Console.ReadKey();
                                break;     
                            case "2":
                                DataClass.ShowData("Buildings", "building.xml");
                                Console.ReadKey();
                                break;     
                            case "3":
                                DataClass.ShowData("Hotel rooms", "hotelRooms.xml");
                                Console.ReadKey();
                                break;
                        }                       
                        break;
                    case "2":
                        Console.Beep();
                        Console.Clear();
                        Console.WriteLine("Ñhoose data to add:");
                        Console.WriteLine("1. People");
                        Console.WriteLine("2. Buildings");
                        Console.WriteLine("3. Hotel rooms");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.Clear();
                                Console.WriteLine("Enter data:");
                                Console.WriteLine("============:");
                                Console.WriteLine("Name:");
                                string name = Console.ReadLine();
                                Console.WriteLine("Last name:");
                                string lastName = Console.ReadLine();
                                Console.WriteLine("Age:");
                                int age = Convert.ToInt32(Console.ReadLine());
                                Person.AddData(new Person("people.xml", name, lastName, age));
                                break;
                            case "2":
                                break;
                            case "3":
                                break;
                        }
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Beep();
                        Console.Clear();
                        Console.WriteLine("Ñhoose data to delete:");
                        Console.WriteLine("1. People");
                        Console.WriteLine("2. Buildings");
                        Console.WriteLine("3. Hotel rooms");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                DataClass.ShowData("Persons", "people.xml");
                                Console.WriteLine("Enter ID: ");
                                DataClass.DeleteData(Console.ReadLine(), "people.xml");
                                break;
                            case "2":
                                DataClass.ShowData("Buildings", "building.xml");
                                Console.WriteLine("Enter ID: ");
                                DataClass.DeleteData(Console.ReadLine(), "building.xml");
                                break;
                            case "3":
                                DataClass.ShowData("Hotel rooms", "hotelRooms.xml");
                                Console.WriteLine("Enter ID: ");
                                DataClass.DeleteData(Console.ReadLine(), "hotelRooms.xml");
                                break;
                        }
                        break;
                    case "4":
                        Console.Beep();
                        isWorking = !isWorking;
                        break;
                    default:
                        isWorking = !isWorking;
                        break;
                }
                Console.Clear();
            }
        }
    }
}