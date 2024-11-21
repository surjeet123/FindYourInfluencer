using FYI.Business.Models.Utilities;
using FYI.Data.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Services.Utilities
{
    public class EncryptionUtilities
    {
        private const string EncryptionKey = "xG7z4EmPCnVvT8D2j9qYhMqW8LyQR8sJ";
        public static HashedEncryptionModel HashRawText(string value)
        {
            // Generate a salt
            byte[] saltBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            string salt = Convert.ToBase64String(saltBytes);

            // Hash the password with the salt
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: value,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return new HashedEncryptionModel { HashedValue = hashedPassword, Salt = salt };
        }

        public static bool VerifyHashValue(string value, string storedHashedValue, string storedSalt)
        {
            byte[] saltBytes = Convert.FromBase64String(storedSalt);
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: value,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashedPassword == storedHashedValue;
        }
        public static string Encrypt(string plainText)
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(EncryptionKey);
            aes.IV = RandomNumberGenerator.GetBytes(16); // Zero IV for simplicity

            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            using (var sw = new StreamWriter(cs)) { sw.Write(plainText); }

            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string encryptedText)
        {
            byte[] cipherBytes = Convert.FromBase64String(encryptedText);

            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(EncryptionKey);

            // Extract the IV from the encrypted data
            byte[] iv = new byte[16];
            Array.Copy(cipherBytes, 0, iv, 0, iv.Length);
            aes.IV = iv;

            // Decrypt the data
            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream(cipherBytes, 16, cipherBytes.Length - 16);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);

            return sr.ReadToEnd();
        }
        public static int Generate4DigitNumber()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] bytes = new byte[2]; // 16 bits = enough to generate a number in the 4-digit range
                rng.GetBytes(bytes);

                // Convert bytes to a number and limit to 4-digit range
                int value = BitConverter.ToUInt16(bytes, 0) % 9000 + 1000; // Range 1000-9999
                return value;
            }
        }
    }
}
