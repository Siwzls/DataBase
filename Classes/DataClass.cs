using System;
using System.Collections.Generic;
using System.Xml;
namespace DataBase
{
    abstract class DataClass
    {
        protected static XmlDocument xDoc = new XmlDocument();
        public static void ShowData(string typeName, string filename)
        {
            Console.Clear();
            XmlElement xRoot = LoadFile(filename);

            Console.WriteLine("===================");
            Console.WriteLine(typeName);
            Console.WriteLine("===================");
            int currentID = 0;
            int dataCount = 0;
            while (true)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    if (Convert.ToInt32(xnode.Attributes.GetNamedItem("id").Value) == currentID)
                    {
                        Console.WriteLine("ID:" + xnode.Attributes.GetNamedItem("id").Value);
                        foreach (XmlNode childnode in xnode.ChildNodes) Console.WriteLine($"{childnode.Name.ToUpper()}: {childnode.InnerText}");
                        Console.WriteLine("-------------------");
                        dataCount++;
                    }
                }
                currentID++;
                if (dataCount == xRoot.ChildNodes.Count) break;
            }
        }
        public static void SearchDataByID(string filename, string typeName, string id)
        {
            Console.Clear();
            XmlElement xRoot = LoadFile(filename);

            Console.WriteLine("=================");
            Console.WriteLine(typeName);
            Console.WriteLine("=================");
            foreach (XmlElement xnode in xRoot)
            {
                if (xnode.Attributes.GetNamedItem("id").Value == id)
                {
                    Console.WriteLine("ID:" + xnode.Attributes.GetNamedItem("id").Value);
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        Console.WriteLine($"{childnode.Name.ToUpper()}: {childnode.InnerText}");
                    }
                }
            }
        }
        public static void SearchDataByParameters(string filename, string typeName)
        {
            Console.Clear();
            XmlElement xRoot = LoadFile(filename);

            Console.WriteLine("===================");
            Console.WriteLine(typeName);
            Console.WriteLine("===================");

            List<int> iList = new List<int>();
            int i = 1;
            foreach (XmlNode childnode in xRoot.ChildNodes[0].ChildNodes)
            {
                Console.WriteLine($"{i}. {childnode.Name.ToUpper()}");
                iList.Add(i);
                i++;
            }
            Console.WriteLine("-------------------");
            Console.WriteLine("Enter parameter:");
            int param = Convert.ToInt32(EnterData(typeof(int)));
            Console.Clear();
            Console.WriteLine("Enter data:");
            string data = EnterData(typeof(Type));
            Console.Clear();
            for (i = 0; i < xRoot.ChildNodes.Count; i++)
            {
                for (int j = 0; j < xRoot.ChildNodes[i].ChildNodes.Count; j++)
                {
                    if (j + 1 == param)
                    {
                        if (xRoot.ChildNodes[i].ChildNodes[j].InnerText == data)
                        {
                            Console.Clear();
                            Console.WriteLine("================");
                            Console.WriteLine(typeName);
                            Console.WriteLine("================");
                            foreach (XmlNode childnode in xRoot.ChildNodes[i].ChildNodes) Console.WriteLine($"{childnode.Name.ToUpper()}: {childnode.InnerText}");
                            Console.ReadKey();
                        }
                    }
                    else continue;
                }
            }
        }
        public static void SearchDataBySummary()
        {  
            string[] filesToLoad = { "people.xml", "building.xml", "hotelRooms.xml" };

            Console.Clear();
            Console.WriteLine("Enter data:");
            string data = EnterData(typeof(Type));
            for (int x = 0; x < filesToLoad.Length; x++)
            {
                Console.Clear();
                XmlElement xRoot = LoadFile(filesToLoad[x]);

                for (int i = 0; i < xRoot.ChildNodes.Count; i++)
                {
                    for (int j = 0; j < xRoot.ChildNodes[i].ChildNodes.Count; j++)
                    {
                        if (xRoot.ChildNodes[i].ChildNodes[j].InnerText == data)
                        {
                            Console.WriteLine("===================");
                            Console.WriteLine($"Person ID: {xRoot.ChildNodes[i].Attributes.GetNamedItem("id").Value}");
                            Console.WriteLine("-------------------");
                            foreach (XmlNode childnode in xRoot.ChildNodes[i].ChildNodes) Console.WriteLine($"{childnode.Name.ToUpper()}: {childnode.InnerText}");
                            Console.WriteLine("===================");
                            Console.WriteLine();
                            Console.WriteLine("-  -  -  -  -  -  -");
                            Console.WriteLine();
                            
                        }
                    }
                }
                Console.WriteLine("Press Enter to continue . . .");
                Console.ReadKey();
            } 
        }
        public static void EditData(string filename, string typeName)
        {
            Console.Clear();

            ShowData(typeName, filename);
            XmlElement xRoot = xDoc.DocumentElement;
            if (xRoot.ChildNodes.Count > 1)
            {
                Console.WriteLine("Enter ID:");
                string inputID = EnterData(typeof(int));
                Console.Clear();

                //������� ���������
                foreach (XmlElement xnode in xRoot)
                {
                    if (xnode.Attributes.GetNamedItem("id").Value == inputID)
                    {
                        foreach (XmlNode childnode in xnode.ChildNodes)
                        {
                            Console.WriteLine($"{childnode.Name.ToUpper()}: {childnode.InnerText}");
                        }
                    }
                }
                Console.WriteLine("-------------------");

                //��������� ������ ����������
                List<int> iList = new List<int>();
                int i = 1;
                foreach (XmlNode childnode in xRoot.ChildNodes[0].ChildNodes)
                {
                    Console.WriteLine($"{i}. {childnode.Name.ToUpper()}");
                    iList.Add(i);
                    i++;
                }
                Console.WriteLine("Select parameter to edit:");
                int param = Convert.ToInt32(EnterData(typeof(int)));
                Console.Clear();
                foreach (XmlNode xnode in xRoot)
                {
                    if (xnode.Attributes.GetNamedItem("id").Value == inputID)
                    {
                        for (i = 0; i < xRoot.ChildNodes[0].ChildNodes.Count; i++)
                        {
                            if (i == param - 1)
                            {
                                Type type;
                                if (char.IsDigit(xnode.ChildNodes[i].InnerText[0])) type = typeof(int);
                                else type = typeof(string);

                                Console.WriteLine("Enter data:");
                                string data = EnterData(type);
                                xnode.ChildNodes[i].InnerText = data;
                                break;
                            }
                        }
                    }
                }
                xDoc.Save(@"..\..\..\DB\" + filename);
                ShowData(typeName, filename);
                Console.WriteLine("Data is saved!");
                Console.ReadKey();
            }
        }
        public static void DeleteData(string dataID, string filename)
        {
            XmlElement xRoot = LoadFile(filename);
  
            foreach (XmlNode xnode in xRoot) if (xnode.Attributes.GetNamedItem("id").Value == dataID) xRoot.RemoveChild(xnode);
            xDoc.Save($@"..\..\..\DB\{filename}");
        }
        protected static XmlElement LoadFile(string filename) 
        {
            xDoc.Load($@"..\..\..\DB\{filename}");
            XmlElement xRoot = xDoc.DocumentElement;
            return xRoot;
        }
        public static string EnterData(Type type)
        {
            bool isWorking = true;
            string data = Console.ReadLine();
            while (isWorking)
            {
                if (data != null)
                {
                    if(type.Equals(typeof(int)))
                    {
                        foreach (char c in data)
                        {
                            if (!char.IsDigit(c))
                            {
                                Console.WriteLine("Your data type is wrong");
                                data = null;
                                break;
                            }
                            else return data;
                        }
                    }
                    else if(type.Equals(typeof(string)))
                    {
                        foreach (char c in data)
                        {
                            if (!char.IsLetter(c))
                            {
                                Console.WriteLine("Your data type is wrong");
                                data = null;
                                break;
                            }
                            else return data;
                        }
                    } 
                    else return data;
                }
                else
                {
                    Console.WriteLine("Enter a new data:");
                    data = Console.ReadLine();
                    continue;
                }
            }
            return null;
        }
        public static int GetFreeId(XmlElement xRoot)
        {
            List<int> idList = new List<int>();
            int i = 0;
            foreach (XmlElement xnode in xRoot)
            {
                string attrId = xnode.Attributes.GetNamedItem("id").Value;
                int currentId = Convert.ToInt32(attrId);

                idList.Add(currentId);
                i++;
            }
            idList.Sort();
            int freeId = 0;
            for (i = 0; i < idList.Count; i++)
            {
                if (freeId == idList[i]) freeId++;
                else break;
            }
            return freeId;
        }
        public static bool CheckId(string filename, string id)
        {
            XmlElement xRoot = LoadFile(filename);
            List<int> idList = new List<int>();
            int i = 0;
            foreach (XmlElement xnode in xRoot)
            {
                string attrId = xnode.Attributes.GetNamedItem("id").Value;
                int currentId = Convert.ToInt32(attrId);

                idList.Add(currentId);
                i++;
            }
            idList.Sort();
            for (i = 0; i < idList.Count; i++)
            {
                if (Convert.ToInt32(id) == idList[i]) return true;
            }
            Console.WriteLine("This ID is not exist");
            return false;
        }
    }
}