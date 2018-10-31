using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Mystivate.Logic
{
    public static class PasswordEncryptor
    {
        public static EncryptedPassword EncryptPassword(string pass)
        {
            var deriveBytes = new Rfc2898DeriveBytes(pass, 20);
            byte[] salt = deriveBytes.Salt;
            byte[] key = deriveBytes.GetBytes(20); // 20-byte key

            string passSalt = Convert.ToBase64String(salt);
            string passKey = Convert.ToBase64String(key);

            deriveBytes.Dispose();

            return new EncryptedPassword { PasswordSalt = passSalt, PasswordKey = passKey };
        }

        public static bool PasswordCorrect(string pass, EncryptedPassword encryptedPass)
        {
            // load encodedSalt and encodedKey from database for the given username
            byte[] salt = Convert.FromBase64String(encryptedPass.PasswordSalt);
            byte[] key = Convert.FromBase64String(encryptedPass.PasswordKey);

            var deriveBytes = new Rfc2898DeriveBytes(pass, salt);
            byte[] testKey = deriveBytes.GetBytes(20); // 20-byte key
            deriveBytes.Dispose();

            if (!testKey.SequenceEqual(key))
                return false;
            else
                return true;
        }
    }
}
