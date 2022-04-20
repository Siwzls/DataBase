using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    class HotelRoom : DataClass
    {
        public static void AddData(string filename, string roomCount, string buildingID)
        {
            XmlElement xRoot = LoadFile(filename);

            XmlElement mainElem = xDoc.CreateElement("building");
            XmlElement roomCountElem = xDoc.CreateElement("roomCount");
            XmlElement buildingIdElem = xDoc.CreateElement("buildingId");

            XmlAttribute idAttr = xDoc.CreateAttribute("id");
            XmlText idText = xDoc.CreateTextNode(Convert.ToString(GetFreeId(xRoot)));
            XmlText roomCountText = xDoc.CreateTextNode(roomCount);
            XmlText buildingIdText = xDoc.CreateTextNode(buildingID);

            roomCountElem.AppendChild(roomCountText);
            buildingIdElem.AppendChild(buildingIdText);

            idAttr.AppendChild(idText);
            mainElem.Attributes.Append(idAttr);
            mainElem.AppendChild(roomCountElem);
            mainElem.AppendChild(buildingIdElem);

            xRoot.AppendChild(mainElem);
            xDoc.Save($@"..\..\..\DB\{filename}");
            Console.WriteLine("Data is saved!");
        }
    }
}
