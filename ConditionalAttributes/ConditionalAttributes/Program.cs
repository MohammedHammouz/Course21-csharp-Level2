#define EnabledConditional
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalAttributes
{
    public class MyClass
    {
        [Conditional("DEBUG")]
        public void DebugMethod()
        {
            Console.WriteLine("This is debug method");
        }
        public void NormalMethod()
        {
            Console.WriteLine("This is normal method");
        }
        [Conditional("EnabledConditional")]
        public void EnabledConditionalMethod()
        {
            Console.WriteLine("This is Enabled Conditional method");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass myObject = new MyClass();
            myObject.DebugMethod();
            myObject.NormalMethod();
            myObject.EnabledConditionalMethod();
        }
    }
}
