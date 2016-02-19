using System;
using System.IO;

namespace ComLib.Extensions
{
    public static class NumberExtensions
    {
        private static readonly string[] Sizes = { "B", "KB", "MB", "GB", "TB", "PB" };

        #region ToFileSizeString
        /// <summary>
        /// Template method for ToFileSizeString
        /// </summary>
        private static Tuple<int, double> FileSizeCalculation(double length)
        {
            int sizeIndex = 0;
            while (length >= 1024 && sizeIndex + 1 < Sizes.Length)
            {
                sizeIndex++;
                length = length / 1024;
            }

            return new Tuple<int, double>(sizeIndex, length);
        }

        /// <summary>
        /// Turns number into a file size string.
        /// <para/> Example: "9.54 MB"
        /// </summary>
        public static string ToFileSizeString(this long size)
        {
            Tuple<int, double> result = FileSizeCalculation(size);
            return string.Format("{0:0.##} {1}", result.Item2, Sizes[result.Item1]);
        }

        /// <summary>
        /// Turns number into a file size string.
        /// <para/> Example: "9.54 MB"
        /// </summary>
        public static string ToFileSizeString(this int size)
        {
            Tuple<int, double> result = FileSizeCalculation(size);
            return string.Format("{0:0.##} {1}", result.Item1, result.Item2);
        }

        /// <summary>
        /// Turns number into a file size string.
        /// <para/> Example: "9.54 MB"
        /// </summary>
        public static string ToFileSizeString(this double size)
        {
            Tuple<int, double> result = FileSizeCalculation(size);
            return string.Format("{0:0.##} {1}", result.Item1, result.Item2);
        }
        #endregion
    }
}
