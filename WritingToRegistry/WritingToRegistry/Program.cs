using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
namespace WritingToRegistry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string KeyPath = @"HKEY_CURRENT_USER\Software\MySoftWare";
            string ValueName = "UserName";
            string ValueData = "User123";
            try
            {
                Registry.SetValue(KeyPath, ValueName, ValueData, RegistryValueKind.String);
                Console.WriteLine($"Value {ValueName} successfully written to the Registry.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
