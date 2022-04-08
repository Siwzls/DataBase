using System;
using System.IO;
using System.Xml;
namespace DataBase
{
    abstract class DataClass
    {
        protected int id;
        protected string filename;
        XmlDocument xDoc = new XmlDocument();
        public void ShowData()
        {
            xDoc.Load($@"..\..\..\DB\{filename}");
            XmlElement xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    //XmlNode attr = xnode.Attributes.GetNamedItem("id");
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "name")
                        {
                            //Console.WriteLine($"Name: {childnode.InnerText}");
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}