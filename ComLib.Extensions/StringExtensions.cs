using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ComLib.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Inserts the args into the format string.
        /// </summary>
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }
        
        /// <summary>
        /// Checks if the string contains another string.
        /// </summary>
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }
        
        /// <summary>
        /// Replaces substring inside string where matched. Will return original if no match found.
        /// </summary>
        public static string Replace(this string source, string oldString, string newString, StringComparison comp)
        {
            int index = source.IndexOf(oldString, comp);
            bool matchFound = index >= 0;

            if (matchFound)
            {
                // Remove the old text.
                source = source.Remove(index, oldString.Length);

                // Add the new text.
                source = source.Insert(index, newString);
            }

            return source;
        }
        
        /// <summary>
        /// Checks if the string matches the regex pattern.
        /// </summary>
        public static bool IsMatch(this string value, string pattern)
        {
            Regex regex = new Regex(pattern);
            return regex.IsMatch(value);
        }
        
        /// <summary>
        /// Checks if the string matches many regex patterns.
        /// </summary>
        public static bool IsMatch(this string value, params string[] patterns)
        {
            foreach (string pat in patterns)
            {
                Regex regex = new Regex(pat);
                if (regex.IsMatch(value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        
    }
}
