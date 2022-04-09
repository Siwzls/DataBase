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

            //Создаются узлы
            XmlElement personElem = xDoc.CreateElement("person");
            XmlElement nameElem = xDoc.CreateElement("name");
            XmlAttribute idAttr = xDoc.CreateAttribute("id");
            XmlText idText = xDoc.CreateTextNode(Convert.ToString(GetFreeId(xRoot)));

            //Придаётся значение аттрибутам и тегам
            idAttr.AppendChild(idText);
            personElem.Attributes.Append(idAttr);   
            nameElem.InnerText = "TestName";

            //Приклепляются теги друг к другу
            personElem.AppendChild(nameElem);
            xRoot.AppendChild(personElem);
            xDoc.Save($@"..\..\..\DB\{filename}");
            Console.WriteLine("Data is saved!");
        }
        public void DeleteData(int dataID)
        {
            XmlElement xRoot = LoadFile(filename);

            foreach (XmlElement xnode in xRoot)
            {
                int id = Convert.ToInt32(xnode.Attributes.GetNamedItem("id").Value);
                if (dataID == id)
                {
                    xnode.RemoveAll();
                }
            }
        }
        //Метод, который загружает файл и возращает объект типа XmlElement 
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
                    else
                    {
                        freeId = prevId + 1;
                        break;
                    }
                }
            }
            return freeId;
        }
    }
}