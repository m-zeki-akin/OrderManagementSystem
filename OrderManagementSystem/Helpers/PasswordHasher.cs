using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace OrderManagementSystem.Helpers;

public static class PasswordHasher
{
    public static string HashPassword(string password)
    {
        byte[] salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8
            ));
    }

    public static bool VerifyHashedPassword(string hashedPassword, string password)
    {
        var hashedProvidedPassword = HashPassword(password);
        return hashedPassword == hashedProvidedPassword;
    }
}