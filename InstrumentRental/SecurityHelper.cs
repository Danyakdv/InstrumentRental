using System;
using System.Security.Cryptography;
using System.Text;

namespace InstrumentRental
{
    public static class SecurityHelper
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // x2 - нижний регистр
                }
                return builder.ToString();
            }
        }
    }
}