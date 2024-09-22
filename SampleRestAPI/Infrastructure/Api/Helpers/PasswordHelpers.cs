using System.Security.Cryptography;
using System.Text;

namespace SampleRestAPI.infrastructure.Api.Helpers;

public static class PasswordHelpers
{
    
    public static string HashPassword(string password)
    {
        // Convert the input string to a byte array and compute the hash
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

        // Convert byte array to a string representation (hexadecimal format)
        var builder = new StringBuilder();
        foreach (var t in bytes)
        {
            builder.Append(t.ToString("x2")); // "x2" formats as hexadecimal
        }

        return builder.ToString();
    }

}