using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace BinarySerialization
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person { Name = "Mohammed Hammouz", Age = 31 };
            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream stream=new FileStream("Person.bin", FileMode.Create))
            {
                formatter.Serialize(stream, person);
            }
            using(FileStream stream =new FileStream("Person.bin", FileMode.Open))
            {
                Person DeserializePerson = (Person)formatter.Deserialize(stream);
                Console.WriteLine($"Name:{DeserializePerson.Name},Age:{DeserializePerson.Age}");
            }
        }
    }
}
