using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace JSONSerialization
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
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Person));
            using(MemoryStream stream=new MemoryStream())
            {
                serializer.WriteObject(stream, person);
                string JSONString = Encoding.UTF8.GetString(stream.ToArray());
                File.WriteAllText("Person.Json", JSONString);
            }
            using(FileStream stream=new FileStream("Person.Json", FileMode.Open))
            {
                Person DeserializablePerson = (Person)serializer.ReadObject(stream);
                Console.WriteLine($"Name:{DeserializablePerson.Name},Age:{DeserializablePerson.Age}");
            }
        }
    }
}
