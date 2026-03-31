using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Hashing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string data = "Mohammed Al-Hammouz";
            Console.WriteLine(data);
            Console.WriteLine(ComputeHash(data));
            Console.WriteLine(ComputeHash("Donkey"));
            Console.ReadKey();
        }
        static string ComputeHash(string input)
        {
            using(SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
