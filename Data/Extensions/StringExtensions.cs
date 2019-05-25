using System.Text.RegularExpressions;

namespace Data.Extensions
{
    public static class StringExtensions
    {
        public static string ToExcludeSpecialCharactersAndSpace(this string value)
        {
            return Regex.Replace(value, "[^A-Za-z]", string.Empty);
        }
    }
}