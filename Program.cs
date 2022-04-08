using System;
using System.IO;
using System.Xml;
namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            Person data = new Person("people.xml");
            data.ShowData();
        }
    }
}