using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace Reflection_with_custom_attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,AllowMultiple =true)]
    public class MyCustomAttribute : Attribute
    {
        public string Description { get; }
        public MyCustomAttribute(string description)
        {
            Description = description;
        }
    }
    [MyCustom("This is a class attribute")]
    public class MyClass {
        
        [MyCustom("This is a method attribute")]
        [MyCustom("This is a method attribute in MyClass")]
        public void MyMethod()
        {
            
        }
    }
    
   
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(MyClass);
            object[] classAttributes = type.GetCustomAttributes(typeof(MyCustomAttribute), false);
            foreach(MyCustomAttribute customAttribute in classAttributes)
            {
                Console.WriteLine($"Description:{customAttribute.Description}");
                
            }
            MethodInfo methodInfo = type.GetMethod("MyMethod");
            object[] methodAttributes = methodInfo.GetCustomAttributes(typeof(MyCustomAttribute), false);
            foreach(MyCustomAttribute method in methodAttributes)
            {
                Console.WriteLine($"Description:{method.Description}");
            }
        }
    }
}
