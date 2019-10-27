using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAmThereApi.Helpers
{
    public static class Hasher
    {
        public static string GetHashedString(string value)
        {
            value = BCrypt.Net.BCrypt.HashPassword(value);
            return value;
        }

        public static bool VerifyHash(string value, string hashedValue)
        {
            return BCrypt.Net.BCrypt.Verify(value, hashedValue);
        }
    }
}
