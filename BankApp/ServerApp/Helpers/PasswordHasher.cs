using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ServerApp.Helpers
{
    public static class PasswordHasher
    {
        public static (string hash, string salt) HashPassword(string password)
        {
            byte[] saltBytes = new byte[128 / 8]; 
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            string salt = Convert.ToBase64String(saltBytes);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return (hashed, salt);
        }
        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            byte[] saltBytes = Convert.FromBase64String(storedSalt);
            string enteredHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: enteredPassword,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return enteredHash == storedHash;
        }
    }
}
