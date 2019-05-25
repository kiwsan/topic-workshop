using System;

namespace Data.Utils
{
    public static class StringUtils
    {
        public static string EncodeBase64(string value)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(value));
        }

        public static string DecodeBase64(string value)
        {
            return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(value));
        }
        
    }
}