using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DataBase
{
    static class Program
    {
        /// <summary>
        /// 
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.Run(new Login());
        }
    }
}