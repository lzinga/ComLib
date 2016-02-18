using System;
using System.IO;

namespace ComLib.Extension
{
    public static class NumberExtensions
    {
        /// <summary>
        /// Turns the size into a human readable file size.
        /// </summary>
        public static string FileSizeToString(this long size)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB", "PB" };
            double len = size;
            int order = 0;
            while (len >= 1024 && order + 1 < sizes.Length)
            {
                order++;
                len = len / 1024;
            }

            return string.Format("{0:0.##} {1}", len, sizes[order]);
        }
    }
}
