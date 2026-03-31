using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace SymmetricEncryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string originalData = "Sensitive information";
            string key = "1234567890123456";
            string EncryptorData = Encrypt(originalData, key);
            Console.WriteLine($"Original Data: {originalData}");
            Console.WriteLine($"Encrypted Data: {EncryptorData}");
            Console.WriteLine($"Decrypted Data: {Decrypt(EncryptorData,key)}");
        }
        static string Encrypt(string plainText,string Key)
        {
            using(Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(Key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using(var msEncrypt=new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt,encryptor,CryptoStreamMode.Write))

                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }  
            }
        }
        static string Decrypt(string cipherText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES decryption
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create a decryptor
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);


                // Decrypt the data
                using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                {
                    // Read the decrypted data from the StreamReader
                    return srDecrypt.ReadToEnd();
                }
            }
        }
    }
}
