using System;
using System.Collections.Generic;

namespace ComLib.Extensions
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
        
        /// <summary>
        /// Gets items from a list based on the distinct property.
        /// </summary>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey> (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
