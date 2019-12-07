using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ImdbWebAppCore.Services
{
    public class PasswordHasher
    {
        public static byte[] GetHashed(string str, byte[] salt)
        {
            return KeyDerivation.Pbkdf2(
                password: str,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8);
        }

        public static byte[] GetSalt(int saltSize = 128 / 8)
        {
            byte[] salt = new byte[saltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        public static bool Validate(string str, byte[] hashed, byte[] salt)
        {
            var hashedStr = KeyDerivation.Pbkdf2(
                password: str,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8);
            return hashed.SequenceEqual(hashedStr);
        }

    }
}
