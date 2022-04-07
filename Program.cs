using System;
using System.IO;
using System.Xml;
namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"..\..\..\DB\people.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("id");
                    Console.WriteLine(attr.Value);
                }
            }
            Console.ReadKey();
        }
    }
}