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
                                break;     
                            case "2":
                                DataClass.ShowData("Buildings", "building.xml");
                                break;     
                            case "3":
                                DataClass.ShowData("Hotel rooms", "hotelRooms.xml");
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
                                data = new Person("people.xml");
                                data.AddData();
                                break;
                            case "2":
                                data = new Building("building.xml");
                                data.AddData();
                                break;
                            case "3":
                                data = new HotelRoom("hotelRooms.xml");
                                data.AddData();
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
                                DataClass.DeleteData(Convert.ToInt32(Console.ReadLine()), "people.xml");
                                break;
                            case "2":
                                DataClass.ShowData("Buildings", "building.xml");
                                Console.WriteLine("Enter ID: ");
                                DataClass.DeleteData(Convert.ToInt32(Console.ReadLine()), "building.xml");
                                break;
                            case "3":
                                DataClass.ShowData("Hotel rooms", "hotelRooms.xml");
                                Console.WriteLine("Enter ID: ");
                                DataClass.DeleteData(Convert.ToInt32(Console.ReadLine()), "hotelRooms.xml");
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