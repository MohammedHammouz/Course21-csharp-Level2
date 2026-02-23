using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace TypeClassReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type myType = typeof(string);
            Console.WriteLine($"Name:{myType.Name}");
            Console.WriteLine($"Is Class:{myType.IsClass}");
            Console.WriteLine($"Assembly:{myType.Assembly}");
            Console.WriteLine($"Full Name:{myType.FullName}");  
        }
    }
}
