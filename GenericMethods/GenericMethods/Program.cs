using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMethods
{
    public class Utility
    {
        public static T Swap<T>(ref T num1, ref T num2)
        {
            T temp = num1;
            num1 = num2;
            num2 = temp;
            return temp;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = 10, num2 = 20;
            Console.WriteLine($"Before swap num1={num1},num2={num2}");
            Utility.Swap(ref num1, ref num2);
            Console.WriteLine($"After swap num1={num1},num2={num2}");
            string Word1 = "Hello", Word2 = "World!";
            Console.WriteLine($"Before swap Word1={Word1},Word2={Word2}");
            Utility.Swap(ref Word1, ref Word2);
            Console.WriteLine($"Before swap Word1={Word1},Word2={Word2}");
        }
    }
}
