using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace XMLSerialization
{
    [Serializable]
    
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Users user;
        public class Users
        {
            public string UserName { get; set; }
            public string PassWord { get; set; }
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Person person = new Person ();
            Person.Users user= new Person.Users();
            
            List<Person> ListOfPeople = new List<Person> { new Person { Name = "Mohammed Hammouz", Age = 31,user=new Person.Users {UserName="kjkjsx",PassWord="lskxls" } }, new Person { Name = "Hamdi Hamdi", Age = 25, user = new Person.Users { UserName = "kjkjsx", PassWord = "lskxls" } } };
            
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            using (TextWriter writer = new StreamWriter("person.xml"))
            {
                serializer.Serialize(writer, ListOfPeople);
            };
            using(TextReader reader=new StreamReader("person.xml"))
            {
                List<Person> DeserializePerson = (List<Person>)serializer.Deserialize(reader);
                foreach(Person person1 in DeserializePerson)
                {
                    Console.WriteLine($"Name :{person1.Name} , Age:{person1.Age} , UserName={person1.user.UserName} , Password={person1.user.PassWord}");
                }
            }
        }
    }
}
