using System;
using System.Text.RegularExpressions;

namespace Logocipher
{
    public static class Extensions
    {
        public static string Alphabetize(this string text)
        {
            var characters = text.ToCharArray();
            Array.Sort(characters);
            return new string(characters);
        }

        public static string CleanForCompare(this string text)
        {
            return Regex.Replace(text, @"\s+", "").Alphabetize();
        }
    }
}