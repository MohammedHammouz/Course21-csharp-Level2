using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace CustomAttributesForValidation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RangeAttribute : Attribute { 
        public int Min { get; }
        public int Max { get; }
        public string ErrorMessage { get; set; }
        public RangeAttribute(int min,int max)
        {
            Min = min;
            Max = max;
        }
    }
    public class Person
    {
        [Range(18,99,ErrorMessage ="Age must be between 18 and 99")]
        public int Age { get; set; }
        [Range(1, 30, ErrorMessage = "Experince must be between 1 and 30")]
        public int Experince { get; set; }
        public string Name { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person { Name = "Mohammed Hammouz", Age = 31, Experince = 2 };
            if (ValidatePerson(person))
            {
                Console.WriteLine("Person is valid");
            }
            else
            {
                Console.WriteLine("Person is invalid");
            }
        }
        public static bool ValidatePerson(Person person)
        {
            Type type = typeof(Person);
            foreach(var property in type.GetProperties())
            {
                if (Attribute.IsDefined(property, typeof(RangeAttribute))){
                    var rangeattribute = (RangeAttribute)Attribute.GetCustomAttribute(property, typeof(RangeAttribute));
                    int value = (int)property.GetValue(person);
                    if(value>rangeattribute.Max | value < rangeattribute.Min)
                    {
                        Console.WriteLine($"Validation faild for property {property.Name},{rangeattribute.ErrorMessage}");
                    }
                }
            }
            return true;
        }
    }
}
