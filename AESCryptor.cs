using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OSTIA
{
    public class AESCryptor
    {
        // Encrypts the given plain text using the given password
        public static string Encrypt(string plainText, string password)
        {
            if (string.IsNullOrEmpty(plainText) || string.IsNullOrEmpty(password))
                throw new ArgumentException("Input strings cannot be null or empty.");

            using (Aes aes = Aes.Create())
            {
                byte[] key = CreateKey(password, aes.KeySize / 8);
                byte[] iv = aes.IV; // AES generates a random IV

                aes.Key = key;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Prepend IV to the output
                    memoryStream.Write(iv, 0, iv.Length);

                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(cryptoStream))
                        {
                            writer.Write(plainText);
                        }
                    }

                    // Convert encrypted data to a Base64 string
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }

        // Decrypts the given cipher text using the given password
        public static string Decrypt(string cipherText, string password)
        {
            if (string.IsNullOrEmpty(cipherText) || string.IsNullOrEmpty(password))
                throw new ArgumentException("Input strings cannot be null or empty.");

            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                byte[] key = CreateKey(password, aes.KeySize / 8);

                using (MemoryStream memoryStream = new MemoryStream(cipherBytes))
                {
                    byte[] iv = new byte[aes.BlockSize / 8];
                    memoryStream.Read(iv, 0, iv.Length); // Read IV from the encrypted data

                    aes.Key = key;
                    aes.IV = iv;

                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cryptoStream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }

        // Creates a secure key from the password using SHA-256 hash
        private static byte[] CreateKey(string password, int keySize)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] key = sha256.ComputeHash(passwordBytes);

                // Truncate or pad the key to the required size
                Array.Resize(ref key, keySize);
                return key;
            }
        }
    }
}
