using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingStringBuilder
{
    internal class Program
    {
        static void ConcatenateString(int Iterations)
        {
            string result = "";
            for(int i = 0; i < Iterations; i++)
            {
                result += "a";
            }
        }
        static void ConcatenateStringBuilder(int Iterations)
        {
            StringBuilder SP = new StringBuilder();
            for (int i = 0; i < Iterations; i++)
            {
                SP.Append("A");
                
            }
            string result = SP.ToString();
        }
        static void Main(string[] args)
        {
            int Iterations = 200000;
            Stopwatch SW1 = Stopwatch.StartNew();
            ConcatenateString(Iterations);
            SW1.Stop();
            Console.WriteLine(SW1.ElapsedMilliseconds);
            Stopwatch SW2 = Stopwatch.StartNew();
            ConcatenateStringBuilder(Iterations);
            SW2.Stop();
            Console.WriteLine(SW2.ElapsedMilliseconds);
        }
    }
}
