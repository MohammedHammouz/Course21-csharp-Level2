using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
namespace ReadingFromRegistry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string KeyPath = @"HKEY_CURRENT_USER\Software\MySoftWare";
            string ValueName = "UserName";
            string value = Registry.GetValue(KeyPath, ValueName, null) as string;
            try
            {
                if (value != null)
                {
                    Console.WriteLine($"The value of {ValueName} is: {value}");
                }
                else
                {
                    Console.WriteLine($"Value {ValueName} not found in the Registry.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
