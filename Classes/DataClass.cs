using System;
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
            if (xRoot != null)
            {
                Console.WriteLine("############");
                Console.WriteLine(typeName);
                Console.WriteLine("############");
                foreach (XmlElement xnode in xRoot)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("id");
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
            }
            Console.ReadKey();
            Console.Clear();
        }
        public void SaveData()
        {
            XmlElement xRoot = LoadFile(filename);
            XmlText idText = xDoc.CreateTextNode(Convert.ToString(GetFreeId(xRoot)));

            XmlElement personElem = xDoc.CreateElement("test");
            //XmlAttribute idAttr = xDoc.CreateAttribute("id");

            //idAttr.AppendChild(idText);
            //personElem.Attributes.Append(idAttr);
            personElem.InnerText = "test";

            xRoot.AppendChild(personElem);
            xDoc.Save("people.xml");
        }
        public void DeleteData(int dataID)
        {

        }
        protected XmlElement LoadFile(string filename) 
        {
            xDoc.Load($@"..\..\..\DB\{filename}");
            XmlElement xRoot = xDoc.DocumentElement;
            return xRoot;
        }
        public int GetFreeId(XmlElement xRoot)
        {
            int freeId = 0;
            if (xRoot != null)
            {
                int prevId = -1;
                foreach (XmlElement xnode in xRoot)
                {
                    string attr = xnode.Attributes.GetNamedItem("id").Value;
                    int currentId = Convert.ToInt32(attr);
                    
                    if (prevId + 1 == currentId) prevId = currentId;
                    else freeId = prevId + 1;
                }
            }
            return freeId;
        }
    }
}