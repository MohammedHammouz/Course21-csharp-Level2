using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
namespace DeleteValueFromRegistry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string KeyPath = @"Software\UserInformation";
            string ValueName = "UserInfo";
            try
            {
                using(RegistryKey BaseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using(RegistryKey key = BaseKey.OpenSubKey(KeyPath, true))
                    {
                        if (key != null)
                        {
                            key.DeleteValue(ValueName);
                            Console.WriteLine($"Successfully deleted value '{ValueName}' from registry key '{KeyPath}'");
                        }
                        else
                        {
                            Console.WriteLine($"Registry key '{KeyPath}' not found");
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("UnauthorizedAccessException: Run the program with administrative privileges.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
