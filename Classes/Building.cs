using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DataBase
{
    class Building : DataClass
    {
        public static void AddData(string filename, string floorCount, string street)
        {
            XmlElement xRoot = LoadFile(filename);

            XmlElement mainElem = xDoc.CreateElement("building");
            XmlElement floorCountElem = xDoc.CreateElement("floorcount");
            XmlElement streetElem = xDoc.CreateElement("street");

            XmlAttribute idAttr = xDoc.CreateAttribute("id");
            XmlText idText = xDoc.CreateTextNode(Convert.ToString(GetFreeId(xRoot)));
            XmlText floorCountText = xDoc.CreateTextNode(floorCount);
            XmlText streetText = xDoc.CreateTextNode(street);

            floorCountElem.AppendChild(floorCountText);
            streetElem.AppendChild(streetText);

            idAttr.AppendChild(idText);
            mainElem.AppendChild(streetElem);
            mainElem.AppendChild(floorCountElem);
            mainElem.Attributes.Append(idAttr);

            xRoot.AppendChild(mainElem);
            xDoc.Save($@"..\..\..\DB\{filename}");
            Console.WriteLine("Data is saved!");
        }
    }
}
