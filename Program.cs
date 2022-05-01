using System;
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
                Console.WriteLine("3. Edit Data");
                Console.WriteLine("4. Search Data(WIP)");
                Console.WriteLine("5. Delete Data");
                Console.WriteLine("6. Exit");
                Console.WriteLine("=============");
                Console.WriteLine("Enter your option: ");
                switch (DataClass.EnterData(typeof(int)))
                {
                    //Show Data
                    case "1":
                        Console.Beep();
                        Console.Clear();
                        Console.WriteLine("�hoose data:");
                        Console.WriteLine("1. People");
                        Console.WriteLine("2. Buildings");
                        Console.WriteLine("3. Hotel rooms");
                        switch (DataClass.EnterData(typeof(int))) 
                        {
                            case "1":
                                Console.Beep();
                                DataClass.ShowData("Persons", "people.xml");
                                Console.WriteLine("Press any key to continue . . .");
                                Console.ReadKey();
                                break;     
                            case "2":
                                Console.Beep();
                                DataClass.ShowData("Buildings", "building.xml");
                                Console.WriteLine("Press any key to continue . . .");
                                Console.ReadKey();
                                break;     
                            case "3":
                                Console.Beep();
                                DataClass.ShowData("Hotel rooms", "hotelRooms.xml");
                                Console.WriteLine("Press any key to continue . . .");
                                Console.ReadKey();
                                break;
                        }                       
                        break;
                    //Add data
                    case "2":
                        Console.Beep();
                        Console.Clear();
                        Console.WriteLine("�hoose data to add:");
                        Console.WriteLine("1. People");
                        Console.WriteLine("2. Buildings");
                        Console.WriteLine("3. Hotel rooms");
                        switch (DataClass.EnterData(typeof(int)))
                        {
                            case "1":
                                Console.Beep();
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
                                Console.Beep();
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
                                Console.Beep();
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
                    //Edit Data
                    case "3":
                        Console.Beep();
                        Console.Clear();
                        Console.WriteLine("�hoose data to add:");
                        Console.WriteLine("1. People");
                        Console.WriteLine("2. Buildings");
                        Console.WriteLine("3. Hotel rooms");
                        switch (DataClass.EnterData(typeof(int)))
                        {
                            case "1":
                                DataClass.EditData("people.xml", "Persons");
                                break;
                            case "2":
                                DataClass.EditData("building.xml", "Building");
                                break;
                            case "3":
                                DataClass.EditData("hotelRooms.xml", "Hptel rooms");
                                break;
                        }
                        break;
                   //Search Data
                    case "4":
                        Console.Beep();
                        Console.Clear();
                        Console.WriteLine("Search data by:");
                        Console.WriteLine("1. ID");
                        Console.WriteLine("2. Parameters");
                        Console.WriteLine("3. Summary");
                       
                        switch (DataClass.EnterData(typeof(int)))
                        {
                            case "1":
                                Console.Beep();
                                Console.WriteLine("�hoose data to search:");
                                Console.WriteLine("1. People");
                                Console.WriteLine("2. Buildings");
                                Console.WriteLine("3. Hotel rooms");
                                switch (DataClass.EnterData(typeof(int)))
                                {
                                    case "1":
                                        Console.Beep();
                                        Console.Clear();
                                        Console.WriteLine("Enter ID:");
                                        string idPeople;
                                        while (true)
                                        {
                                            idPeople = DataClass.EnterData(typeof(int));
                                            if (DataClass.CheckId("people.xml", idPeople)) break;
                                        }
                                        DataClass.SearchDataByID("people.xml", "Persons", idPeople);
                                        Console.Beep();
                                        Console.WriteLine("Press any key to continue . . .");
                                        Console.ReadKey();
                                        break;
                                    case "2":
                                        Console.Beep();
                                        Console.Clear();
                                        Console.WriteLine("Enter ID:");
                                        string idBuilding;
                                        while (true)
                                        {
                                            idBuilding = DataClass.EnterData(typeof(int));
                                            if (DataClass.CheckId("building.xml", idBuilding)) break;
                                        }
                                        DataClass.SearchDataByID("building.xml", "Buildings", idBuilding);
                                        Console.Beep();
                                        Console.WriteLine("Press any key to continue . . .");
                                        Console.ReadKey();
                                        break;
                                    case "3":
                                        Console.Beep();
                                        Console.Clear();
                                        Console.WriteLine("Enter ID:");
                                        string idHotelRoom;
                                        while (true)
                                        {
                                            idHotelRoom = DataClass.EnterData(typeof(int));
                                            if (DataClass.CheckId("hotelRooms.xml", idHotelRoom)) break;
                                        }
                                        DataClass.SearchDataByID("hotelRooms.xml", "Hotel Rooms", idHotelRoom);
                                        Console.Beep();
                                        Console.WriteLine("Press any key to continue . . .");
                                        Console.ReadKey();
                                        break;
                                }
                                break;
                            case "2":
                                Console.Beep();
                                Console.WriteLine("�hoose data to search:");
                                Console.WriteLine("1. People");
                                Console.WriteLine("2. Buildings");
                                Console.WriteLine("3. Hotel rooms");
                                switch (DataClass.EnterData(typeof(int)))
                                {
                                    case "1":
                                        Console.Beep();
                                        Console.Clear();
                                        DataClass.SearchDataByParameters("people.xml", "Persons");
                                        Console.WriteLine("Press any key to continue . . .");
                                        Console.ReadKey();
                                        break;
                                    case "2":
                                        Console.Beep();
                                        Console.Clear();
                                        DataClass.SearchDataByParameters("building.xml", "Buildings");
                                        Console.WriteLine("Press any key to continue . . .");
                                        Console.ReadKey();
                                        break;
                                    case "3":
                                        Console.Beep();
                                        Console.Clear();
                                        DataClass.SearchDataByParameters("hotelRoom.xml", "Hotel Rooms");
                                        Console.WriteLine("Press any key to continue . . .");
                                        Console.ReadKey();
                                        break;
                                }
                                break;
                            case "3":
                                Console.Beep();
                                Console.Clear();
                                DataClass.SearchDataBySummary();           
                                Console.ReadKey();
                                break;
                        }
                        break;
                    //Delete Data
                    case "5":
                        Console.Beep();
                        Console.Clear();
                        Console.WriteLine("�hoose data to delete:");
                        Console.WriteLine("1. People");
                        Console.WriteLine("2. Buildings");
                        Console.WriteLine("3. Hotel rooms");
                        switch (DataClass.EnterData(typeof(int)))
                        {
                            case "1":
                                Console.Beep();
                                DataClass.ShowData("Persons", "people.xml");
                                Console.WriteLine("Enter ID: ");
                                DataClass.DeleteData(DataClass.EnterData(typeof(int)), "people.xml");
                                Console.Clear();
                                Console.WriteLine("Data was deleted successfully.");
                                Console.ReadKey();
                                break;
                            case "2":
                                Console.Beep();
                                DataClass.ShowData("Buildings", "building.xml");
                                Console.WriteLine("Enter ID: "); 
                                DataClass.DeleteData(DataClass.EnterData(typeof(int)), "building.xml");
                                Console.Clear();
                                Console.WriteLine("Data was deleted successfully.");
                                Console.ReadKey();
                                break;
                            case "3":
                                Console.Beep();
                                DataClass.ShowData("Hotel rooms", "hotelRooms.xml");
                                Console.WriteLine("Enter ID: ");
                                DataClass.DeleteData(DataClass.EnterData(typeof(int)), "hotelRooms.xml");
                                Console.Clear();
                                Console.Beep();
                                Console.WriteLine("Data was deleted successfully.");
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue . . .");
                                Console.ReadKey();
                                Console.Beep();
                                break;
                        }
                        break;
                    case "6":
                        Console.Beep();
                        isWorking = !isWorking;
                        break;
                    default:
                        Console.Clear();
                        Console.Beep();
                        Console.WriteLine("Your option is not valid, please select an option from 1 to 5");
                        Console.WriteLine();
                        Console.WriteLine("To continue, press any key . . .");
                        Console.ReadKey();
                        Console.Beep();
                        break;
                }
                Console.Clear();
            }
        }
    }
}