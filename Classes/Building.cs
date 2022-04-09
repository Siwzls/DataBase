using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DataBase
{
    class Building : DataClass
    {
        public int floorCount;

        public Building(string filename, int floorCount)
        {
            this.filename = filename;
            this.floorCount = floorCount;
        }
        public override void AddData()
        {
            XmlElement xRoot = LoadFile(filename);

            XmlElement mainElem = xDoc.CreateElement("building");
            XmlAttribute idAttr = xDoc.CreateAttribute("id");
            XmlText idText = xDoc.CreateTextNode(Convert.ToString(GetFreeId(xRoot)));

            idAttr.AppendChild(idText);
            mainElem.Attributes.Append(idAttr);   

            xRoot.AppendChild(mainElem);
            xDoc.Save($@"..\..\..\DB\{filename}");
            Console.WriteLine("Data is saved!");
        }
    }
}
