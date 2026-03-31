using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace AppConfiguration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConfigurationManager.AppSettings["Mohammed"]);
            Console.WriteLine(ConfigurationManager.AppSettings["Skill1"]);
            Console.WriteLine(ConfigurationManager.AppSettings["Skill2"]);
            Console.WriteLine(ConfigurationManager.AppSettings["Skill3"]);
        }
    }
}
