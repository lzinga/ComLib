using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComLib.Unity.Extensions
{
    public static class GenericExtensions
    {
        private static System.Random rand = new System.Random((int)DateTime.Now.Ticks);

        /// <summary>
        /// Returns a random entry in an array
        /// </summary>
        /// <returns>Random entry in array</returns>
        public static T GetRandom<T>(this T[] val)
        {
            return val[rand.Next(val.Length)];
        }
    }
}
