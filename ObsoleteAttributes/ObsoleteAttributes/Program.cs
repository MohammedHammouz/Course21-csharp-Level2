using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsoleteAttributes
{
    internal class Program
    {
        [Obsolete("This method1 is marked as obsetele method please use method2")]
        public static void Method1()
        {
            Console.WriteLine("Method1");
        }
        public static void Method2()
        {
            Console.WriteLine("Method2");
        }
        static void Main(string[] args)
        {
            Method1();
            Method2();
        }
    }
}
