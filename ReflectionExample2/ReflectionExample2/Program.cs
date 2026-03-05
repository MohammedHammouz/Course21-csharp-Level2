using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace ReflectionExample2
{
    public class MyClass
    {
        public int Property1 { get; set; }
        public void Method1()
        {
            Console.WriteLine("\tMethod1 is executed");
        }
        public void Method2(int value1,string value2)
        {
            Console.WriteLine($"\tMethod2 is executed with parameters:{value1},{value2}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Type myClassType = typeof(MyClass);
            Console.WriteLine($"Name:{myClassType.Name}");
            Console.WriteLine($"Full Name:{myClassType.FullName}");
            Console.WriteLine("Properties:");
            PropertyInfo[] properties = myClassType.GetProperties();
            foreach(var property in properties)
            {
                Console.WriteLine($"Property Name:{property.Name},Property Type:{property.PropertyType}");
            }
            foreach(var method in myClassType.GetMethods())
            {
                Console.WriteLine($"\t{method.ReturnType} {method.Name}({GetListParameter(method.GetParameters())})");
            }
            object myClassInstance = Activator.CreateInstance(myClassType);
            myClassType.GetProperty("Property1").SetValue(myClassInstance, 42);
            Console.WriteLine("Set Property1 to 42 using reflection");
            Console.WriteLine("Getting Property1 is value using reflection");
            int PropertiesValue = (int)myClassType.GetProperty("Property1").GetValue(myClassInstance);
            Console.WriteLine($"\tProperty1 value :{PropertiesValue}");
            Console.WriteLine("\nExecuting methodsusing reflection:\n");
            myClassType.GetMethod("Method1").Invoke(myClassInstance, null);
            object[] parameters = { 40000, "Mohammed Hammouz" };
            myClassType.GetMethod("Method2").Invoke(myClassInstance, parameters);
        }
        static string GetListParameter(ParameterInfo[] parameters)
        {
            return string.Join(",", parameters.Select(parameter => $"{parameter.ParameterType} {parameter.Name}"));
        }
    }
}
