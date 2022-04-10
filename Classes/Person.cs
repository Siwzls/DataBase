using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DataBase
{
    class Person : DataClass
    {
        protected string name;
        protected string lastName;
        protected int age;

        public Person(string filename){
            this.filename = filename;
        }
        public Person(string filename, string name, string lastName, int age)
        {
            this.filename = filename;
            this.name = name;
            this.lastName = lastName;
            this.age = age;
        }
        public void Info()
        {
            Console.WriteLine($"Person name: {name} {lastName}");
            Console.WriteLine($"Person age: {age}");
        }
        public static void AddData(Person data)
        {
            XmlElement xRoot = LoadFile(data.filename);

            XmlElement mainElem = xDoc.CreateElement("person");
            XmlElement nameElem = xDoc.CreateElement("name");
            XmlElement lastNameElem = xDoc.CreateElement("lastName");
            XmlElement ageElem = xDoc.CreateElement("age");

            XmlAttribute idAttr = xDoc.CreateAttribute("id");
            XmlText idText = xDoc.CreateTextNode(Convert.ToString(GetFreeId(xRoot)));
            XmlText nameText = xDoc.CreateTextNode(data.name);
            XmlText lastNameText = xDoc.CreateTextNode(data.lastName);
            XmlText ageText = xDoc.CreateTextNode(Convert.ToString(data.age));

            idAttr.AppendChild(idText);
            nameElem.AppendChild(nameText);
            lastNameElem.AppendChild(lastNameText);
            ageElem.AppendChild(ageText);

            mainElem.Attributes.Append(idAttr);
            mainElem.AppendChild(nameElem);
            mainElem.AppendChild(lastNameElem);
            mainElem.AppendChild(ageElem);

            xRoot.AppendChild(mainElem);
            xDoc.Save($@"..\..\..\DB\{data.filename}");
            Console.WriteLine("Data is saved!");
        }
    }
}
