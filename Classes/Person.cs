using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DataBase
{
    class Person : DataClass
    {
        public static void AddData(string filename, string name ,string lastName, string age)
        {
            XmlElement xRoot = LoadFile(filename);

            XmlElement mainElem = xDoc.CreateElement("person");
            XmlElement nameElem = xDoc.CreateElement("name");
            XmlElement lastNameElem = xDoc.CreateElement("lastName");
            XmlElement ageElem = xDoc.CreateElement("age");

            XmlAttribute idAttr = xDoc.CreateAttribute("id");
            XmlText idText = xDoc.CreateTextNode(Convert.ToString(GetFreeId(xRoot)));
            XmlText nameText = xDoc.CreateTextNode(name);
            XmlText lastNameText = xDoc.CreateTextNode(lastName);
            XmlText ageText = xDoc.CreateTextNode(Convert.ToString(age));

            idAttr.AppendChild(idText);
            nameElem.AppendChild(nameText);
            lastNameElem.AppendChild(lastNameText);
            ageElem.AppendChild(ageText);

            mainElem.Attributes.Append(idAttr);
            mainElem.AppendChild(nameElem);
            mainElem.AppendChild(lastNameElem);
            mainElem.AppendChild(ageElem);

            xRoot.AppendChild(mainElem);
            xDoc.Save($@"..\..\..\DB\{filename}");
            Console.WriteLine("Data is saved!");
        }
    }
}
