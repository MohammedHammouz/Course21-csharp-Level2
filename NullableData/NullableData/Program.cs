using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Nullable<int> nullableInt1 = null;
            if (nullableInt1.HasValue)
            {
                Console.WriteLine($"nulableInt1 has value : {nullableInt1.Value}");
            }
            else{
                Console.WriteLine("nulablleInt1 has no value");
            }
            int? nullableInt2 = 10;
            if (nullableInt2.HasValue)
            {
                Console.WriteLine($"nulableInt1 has value : {nullableInt2.Value}");
            }
            else
            {
                Console.WriteLine("nulablleInt2 has no value");
            }
        }
    }
}
