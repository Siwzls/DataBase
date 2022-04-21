using System;
using System.IO;
using System.Xml;
using System.Windows.Forms;
namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            Console.WriteLine("Hello, choose option:");
            while (isWorking)
            {
                Console.WriteLine("1. Show Data");
                Console.WriteLine("2. Add Data");
                Console.WriteLine("3. Search Data(WIP)");
                Console.WriteLine("4. Delete Data");
                Console.WriteLine("5. Exit");
                Console.WriteLine("=============");
                Console.WriteLine("Enter your option: ");
                switch (DataClass.EnterData(typeof(int)))
                {
                    //Show Data
                    case "1":
                        Console.Beep();
                        Console.Clear();
                        Console.WriteLine("Ñhoose data:");
                        Console.WriteLine("1. People");
                        Console.WriteLine("2. Buildings");
                        Console.WriteLine("3. Hotel rooms");
                        switch (DataClass.EnterData(typeof(int))) 
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
                    //Add data
                    case "2":
                        Console.Beep();
                        Console.Clear();
                        Console.WriteLine("Ñhoose data to add:");
                        Console.WriteLine("1. People");
                        Console.WriteLine("2. Buildings");
                        Console.WriteLine("3. Hotel rooms");
                        switch (DataClass.EnterData(typeof(int)))
                        {
                            case "1":
                                Console.Clear();
                                Console.WriteLine("Enter data:");
                                Console.WriteLine("============:");
                                Console.WriteLine("Name:");
                                string name = DataClass.EnterData(typeof(string));
                                Console.WriteLine("Last name:");
                                string lastName = DataClass.EnterData(typeof(string));
                                Console.WriteLine("Age:");
                                string age = DataClass.EnterData(typeof(int));
                                Person.AddData("people.xml",
                                name, lastName, age);
                                break;
                            case "2":
                                Console.Clear();
                                Console.WriteLine("Enter data:");
                                Console.WriteLine("============:");
                                Console.WriteLine("Floor Count:");
                                string floorCount = DataClass.EnterData(typeof(int));
                                Console.WriteLine("Street:");
                                string street = DataClass.EnterData(typeof(string));
                                Building.AddData("building.xml", floorCount, street);
                                break;
                            case "3":
                                Console.Clear();
                                Console.WriteLine("Enter data:");
                                Console.WriteLine("============:");
                                Console.WriteLine("Rooms count:");
                                string roomCount = DataClass.EnterData(typeof(int));
                                DataClass.ShowData("Buildings", "building.xml");
                                Console.WriteLine("Building ID:");
                                string buildingID;
                                while (true)
                                {
                                    buildingID = DataClass.EnterData(typeof(int));
                                    if (DataClass.CheckId("building.xml", buildingID)) break;
                                } 
                                HotelRoom.AddData("hotelRooms.xml", roomCount, buildingID);
                                break;
                        }
                        Console.ReadKey();
                        break;
                   //Search Data
                    case "3":
                        Console.Beep();
                        Console.Clear();
                        Console.WriteLine("Search data by:");
                        Console.WriteLine("1. ID");
                        Console.WriteLine("2. Parameters");
                        switch (DataClass.EnterData(typeof(int)))
                        {
                            case "1":
                                Console.WriteLine("Ñhoose data to search:");
                                Console.WriteLine("1. People");
                                Console.WriteLine("2. Buildings");
                                Console.WriteLine("3. Hotel rooms");
                                switch (DataClass.EnterData(typeof(int)))
                                {
                                    case "1":
                                        Console.Clear();
                                        Console.WriteLine("Enter ID:");
                                        string idPeople;
                                        while (true)
                                        {
                                            idPeople = DataClass.EnterData(typeof(int));
                                            if (DataClass.CheckId("people.xml", idPeople)) break;
                                        }
                                        DataClass.SearchDataByID("people.xml", "Persons", idPeople);
                                        Console.ReadKey();
                                        break;
                                    case "2":
                                        Console.Clear();
                                        Console.WriteLine("Enter ID:");
                                        string idBuilding;
                                        while (true)
                                        {
                                            idBuilding = DataClass.EnterData(typeof(int));
                                            if (DataClass.CheckId("building.xml", idBuilding)) break;
                                        }
                                        DataClass.SearchDataByID("building.xml", "Buildings", idBuilding);
                                        Console.ReadKey();
                                        break;
                                    case "3":
                                        Console.Clear();
                                        Console.WriteLine("Enter ID:");
                                        string idHotelRoom;
                                        while (true)
                                        {
                                            idHotelRoom = DataClass.EnterData(typeof(int));
                                            if (DataClass.CheckId("hotelRooms.xml", idHotelRoom)) break;
                                        }
                                        DataClass.SearchDataByID("hotelRooms.xml", "Hotel Rooms", idHotelRoom);
                                        Console.ReadKey();
                                        break;
                                }
                                break;
                            case "2":
                                Console.WriteLine("Ñhoose data to search:");
                                Console.WriteLine("1. People");
                                Console.WriteLine("2. Buildings");
                                Console.WriteLine("3. Hotel rooms");
                                switch (DataClass.EnterData(typeof(int)))
                                {
                                    case "1":
                                        Console.Clear();
                                        DataClass.SearchDataByParameters("people.xml", "Persons");
                                        break;
                                    case "2":
                                        Console.Clear();
                                        DataClass.SearchDataByParameters("building.xml", "Buildings");
                                        Console.ReadKey();
                                        break;
                                    case "3":
                                        Console.Clear();
                                        DataClass.SearchDataByParameters("hotelRoom.xml", "Hotel Rooms");
                                        Console.ReadKey();
                                        break;
                                }
                                break;
                        }
                        break;
                    //Delete Data
                    case "4":
                        Console.Beep();
                        Console.Clear();
                        Console.WriteLine("Ñhoose data to delete:");
                        Console.WriteLine("1. People");
                        Console.WriteLine("2. Buildings");
                        Console.WriteLine("3. Hotel rooms");
                        switch (DataClass.EnterData(typeof(int)))
                        {
                            case "1":
                                DataClass.ShowData("Persons", "people.xml");
                                Console.WriteLine("Enter ID: ");
                                DataClass.DeleteData(DataClass.EnterData(typeof(int)), "people.xml");
                                break;
                            case "2":
                                DataClass.ShowData("Buildings", "building.xml");
                                Console.WriteLine("Enter ID: ");
                                DataClass.DeleteData(DataClass.EnterData(typeof(int)), "building.xml");
                                break;
                            case "3":
                                DataClass.ShowData("Hotel rooms", "hotelRooms.xml");
                                Console.WriteLine("Enter ID: ");
                                DataClass.DeleteData(DataClass.EnterData(typeof(int)), "hotelRooms.xml");
                                break;
                        }
                        break;
                    case "5":
                        Console.Beep();
                        isWorking = !isWorking;
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }
    }
}