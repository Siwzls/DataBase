using System;
using System.Collections.Generic;
using System.Xml;
namespace DataBase
{
    abstract class DataClass
    {
        protected int id;
        protected string filename;
        XmlDocument xDoc = new XmlDocument();
        public void ShowData(string typeName)
        {
            XmlElement xRoot = LoadFile(filename);

                Console.WriteLine("############");
                Console.WriteLine(typeName);
                Console.WriteLine("############");
                foreach (XmlElement xnode in xRoot)
                {
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "name")
                        {
                            Console.WriteLine($"Name: {childnode.InnerText}");
                        }
                        if (childnode.Name == "type")
                        {
                            Console.WriteLine($"Type: {childnode.InnerText}");
                            Console.WriteLine("-------------------");
                        }
                    }
                }
            Console.ReadKey();
            Console.Clear();
        }
        public void AddData()
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
        public void DeleteData(int dataID)
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
        protected XmlElement LoadFile(string filename) 
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