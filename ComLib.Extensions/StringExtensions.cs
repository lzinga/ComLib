using System;

namespace ComLib.Extension
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
    }
}
