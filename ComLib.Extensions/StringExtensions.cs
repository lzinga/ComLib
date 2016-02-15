using System;

namespace ComLib.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if string is null or empty.
        /// </summary>
        public static bool IsNullOrEmpty(this string str)
        {
            return String.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Inserts the args into the format string.
        /// </summary>
        public static string Format(this string format, params object[] args)
        {
            return string.Format(format, args);
        }
    }
}
