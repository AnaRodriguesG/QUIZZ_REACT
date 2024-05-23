using System;
using System.Security.Cryptography;

public static class PasswordHasher
{
    public static string HashPassword(string password)
    {
        using (var hmac = new HMACSHA512())
        {
            var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
    }

    public static bool VerifyPassword(string password, string storedHash)
    {
        using (var hmac = new HMACSHA512())
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(computedHash) == storedHash;
        }
    }
}
