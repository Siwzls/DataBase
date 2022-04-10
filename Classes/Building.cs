using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DataBase
{
    class Building : DataClass
    {
        public int floorCount;

        public Building(string filename)
        {
            this.filename = filename;
        }
        public void AddData(Building data)
        {
            XmlElement xRoot = LoadFile(filename);

            XmlElement mainElem = xDoc.CreateElement("building");
            XmlElement floorCountElem = xDoc.CreateElement("floorCount");

            XmlAttribute idAttr = xDoc.CreateAttribute("id");
            XmlText idText = xDoc.CreateTextNode(Convert.ToString(GetFreeId(xRoot)));
            floorCountElem.InnerText = "2";

            idAttr.AppendChild(idText);
            mainElem.AppendChild(floorCountElem);
            mainElem.Attributes.Append(idAttr);   

            xRoot.AppendChild(mainElem);
            xDoc.Save($@"..\..\..\DB\{filename}");
            Console.WriteLine("Data is saved!");
        }
    }
}
