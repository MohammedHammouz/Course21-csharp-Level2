using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace NavigateStringLibraryUsingReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly mscorlib=typeof(string).Assembly;
            Type stringType = mscorlib.GetType("System.String");
            if (stringType != null)
            {
                Console.WriteLine("Methods of System.String class:\n");
                var stringMethods = stringType.GetMethods(BindingFlags.Instance | BindingFlags.Public).OrderBy(method => method.Name);
                foreach(var method in stringMethods)
                {
                    Console.WriteLine($"{method.ReturnType} {method.Name}({GetParameterList(method.GetParameters())})");
                }
            }
            
        }
        static string GetParameterList(ParameterInfo[] parameters)
        {
            return string.Join(",", parameters.Select(parameter => $"{parameter.ParameterType},{parameter.Name}"));
        }
        
    }
}
