using System;
using System.IO;
using System.Xml.Serialization;

namespace ComLib.Extensions
{
    public static class GenericExtensions
    {
        /// <summary>
        /// Checks if object is null or default.
        /// </summary>
        public static void IsNullOrDefault<T>(this T obj, string parameterName) where T : class
        {
            if (obj == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        /// <summary>
        /// Serialize the object into a string.
        /// </summary>
        public static string Serialize<T>(this T obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, obj);
                return textWriter.ToString();
            }
        }

        /// <summary>
        /// Deserializes string into object.
        /// </summary>
        public static T Deserialize<T>(this string data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(data))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
