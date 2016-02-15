using System.Collections.Generic;

namespace ComLib.Extension
{
    public static class ListExtensions
    {
        /// <summary>
        /// Gets string of all items in the collection.
        /// </summary>
        public static string ToString<T>(this IList<T> collection, char seperator = ',')
        {
            return string.Format("{0} {{ {1} }}", collection.GetType().Name, string.Join(string.Format(" {0} ", seperator), collection));
        }
    }
}
