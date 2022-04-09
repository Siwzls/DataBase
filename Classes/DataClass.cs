using System;
using System.Collections.Generic;
using System.Xml;
namespace DataBase
{
    class DataClass
    {
        protected int id;
        protected string filename;
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
            Console.ReadKey();
        }
        public virtual void AddData()
        {
            XmlElement xRoot = LoadFile(filename);

            XmlElement personElem = xDoc.CreateElement("person");
            XmlElement nameElem = xDoc.CreateElement("name");
            XmlAttribute idAttr = xDoc.CreateAttribute("id");
            XmlText idText = xDoc.CreateTextNode(Convert.ToString(GetFreeId(xRoot)));

            idAttr.AppendChild(idText);
            personElem.Attributes.Append(idAttr);   
            nameElem.InnerText = "TestName";

            personElem.AppendChild(nameElem);
            xRoot.AppendChild(personElem);
            xDoc.Save($@"..\..\..\DB\{filename}");
            Console.WriteLine("Data is saved!");
        }
        public static void DeleteData(int dataID, string filename)
        {
            XmlElement xRoot = LoadFile(filename);
  
            foreach (XmlNode xnode in xRoot)
            {
                if(Convert.ToInt32(xnode.Attributes.GetNamedItem("id").Value) == dataID)
                {
                    xRoot.RemoveChild(xnode);
                }
            }
            xDoc.Save($@"..\..\..\DB\{filename}");
        }
        protected static XmlElement LoadFile(string filename) 
        {
            xDoc.Load($@"..\..\..\DB\{filename}");
            XmlElement xRoot = xDoc.DocumentElement;
            return xRoot;
        }
        public int GetFreeId(XmlElement xRoot)
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
    }
}