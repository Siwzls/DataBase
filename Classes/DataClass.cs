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

            Console.WriteLine("############");
            Console.WriteLine(typeName);
            Console.WriteLine("############");
            foreach (XmlElement xnode in xRoot)
            {
                Console.WriteLine("ID:" + xnode.Attributes.GetNamedItem("id").Value);
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    Console.WriteLine($"{childnode.Name.ToUpper()}: {childnode.InnerText}");
                }
                Console.WriteLine("-------------------");
            }
        }
        public static void SearchDataByID(string filename, string typeName, string id)
        {
            Console.Clear();
            XmlElement xRoot = LoadFile(filename);

            Console.WriteLine("############");
            Console.WriteLine(typeName);
            Console.WriteLine("############");
            foreach (XmlElement xnode in xRoot)
            {
                if(xnode.Attributes.GetNamedItem("id").Value == id)
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

            Console.WriteLine("############");
            Console.WriteLine(typeName);
            Console.WriteLine("############");
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
                for(int j = 0; j < xRoot.ChildNodes[i].ChildNodes.Count; j++)
                {
                    if (j+1 == param)
                    {
                        if (xRoot.ChildNodes[i].ChildNodes[j].InnerText == data)
                        {
                            Console.Clear();
                            Console.WriteLine("############");
                            Console.WriteLine(typeName);
                            Console.WriteLine("############");
                            foreach (XmlNode childnode in xRoot.ChildNodes[i].ChildNodes) Console.WriteLine($"{childnode.Name.ToUpper()}: {childnode.InnerText}");
                            Console.ReadKey();
                        }
                    }
                    else continue;
                }
            }
        }
        public static void DeleteData(string dataID, string filename)
        {
            XmlElement xRoot = LoadFile(filename);
  
            foreach (XmlNode xnode in xRoot)
            {
                if (Convert.ToString(xnode.Attributes.GetNamedItem("id").Value) == dataID)
                    xRoot.RemoveChild(xnode);
            }
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
                                Console.WriteLine("Data type is wrong");
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
                                Console.WriteLine("Data type is wrong");
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
            Console.WriteLine("ID is wrong");
            return false;
        }
    }
}