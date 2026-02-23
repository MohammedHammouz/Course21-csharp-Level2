using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
namespace SerializationAttributes
{
    [Serializable]
    public class MyClass
    {
        private int _num1;
        [NonSerialized]
        private int _num2;
        public int num1 {
            get { return _num1; } set { _num1 = value; }
        }
        
        public int num2
        {
            get { return _num2; }
            set { _num2 = value; }
        }
        
        
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass myObject = new MyClass{num1=2,num2=4};
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream("MyClass.bin", FileMode.Create))
            {
                formatter.Serialize(stream, myObject);
            }
            using(FileStream stream =new FileStream("MyClass.bin", FileMode.Open))
            {
                MyClass DeserializeMyClass = (MyClass)formatter.Deserialize(stream);
                Console.WriteLine($"num1={DeserializeMyClass.num1},num2={DeserializeMyClass.num2}");
            }
        }
    }
}
