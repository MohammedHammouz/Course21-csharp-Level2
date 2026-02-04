using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableData
{
    internal class Program
    {
        public class  People
        {
            private string _Name;
            private int _Age;
            public string Name
            {
                get { return _Name; }
                set
                {
                    _Name = value;
                }
            }
            public int Age
            {
                get { return _Age; }
                set
                {
                    _Age = value;
                }
            }
            public People(string Name,int Age)
            {
                _Name = Name;
                _Age = Age;
            }
        }
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
            People person = new People("j", 22);
            Console.WriteLine("Hello world");
        }
        
    }
}
