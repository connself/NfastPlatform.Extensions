﻿using System.IO;

namespace System.Xml.Serialization
{
    public static class SerializationExtensions
    {
        /// <summary>
        ///     An object extension method that serialize a string to XML.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The string representation of the Xml Serialization.</returns>
        public static string SerializeXml(this object @this)
        {
            var xmlSerializer = new XmlSerializer(@this.GetType());

            using (var stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, @this);
                using (var streamReader = new StringReader(stringWriter.GetStringBuilder().ToString()))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        /// <summary>
        ///     A string extension method that deserialize an Xml as &lt;T&gt;.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The desieralize Xml as &lt;T&gt;</returns>
        public static T DeserializeXml<T>(this string @this)
        {
            var x = new XmlSerializer(typeof(T));
            var r = new StringReader(@this);

            return (T)x.Deserialize(r);
        }
    }
}
