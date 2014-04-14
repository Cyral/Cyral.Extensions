using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Cyral.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Checks to see if any of the object(s) in the collection are equal to the source value.
        /// </summary>
        /// <typeparam name="T">The type of object used.</typeparam>
        /// <param name="source">The source object.</param>
        /// <param name="list">The possible objects to equal.</param>
        /// <returns>True of any object(s) are equal to the source, false otherwise.</returns>
        public static bool EqualsAny<T>(this T source, params T[] list)
        {
            if (null == source) throw new ArgumentNullException("source");
            return list.Contains(source);
        }

        /// <summary>
        /// Checks to see if all of the object(s) in the collection are not equal to the souce value.
        /// </summary>
        /// <typeparam name="T">The type of object used.</typeparam>
        /// <param name="source">The source object.</param>
        /// <param name="list">The possible objects to equal.</param>
        /// <returns>True of all object(s) are not equal to the source, false otherwise.</returns>
        public static bool EqualsNone<T>(this T source, params T[] list)
        {
            if (null == source) throw new ArgumentNullException("source");
            return !list.EqualsAny(list);
        }
       
        /// <summary>
        /// Determines whether the object is excactly of the passed type
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="type">The target type.</param>
        /// <returns>
        /// <c>true</c> if the object is of the specified type; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsOfType(this object obj, Type type)
        {
            return (obj.GetType().Equals(type));
        }

        /// <summary>
        /// Determines whether the object is of the passed generic type or inherits from it.
        /// </summary>
        /// <typeparam name="T">The target type.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <returns><c>true</c> if the object is of the specified type; otherwise, <c>false</c>.</returns>
        public static bool IsOfTypeOrInherits<T>(this object obj)
        {
            return obj.IsOfTypeOrInherits(typeof(T));
        }

        /// <summary>
        /// Determines whether the object is of the passed type or inherits from it.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="type">The target type.</param>
        /// <returns><c>true</c> if the object is of the specified type; otherwise, <c>false</c>.</returns>
        public static bool IsOfTypeOrInherits(this object obj, Type type)
        {
            var objectType = obj.GetType();

            while (true)
            {
                if (objectType.Equals(type))
                    return true;
                if ((objectType == objectType.BaseType) || (objectType.BaseType == null))
                    return false;
                objectType = objectType.BaseType;
            }
        }

        /// <summary>
        /// Returns a string representation of the given object.
        /// </summary>
        public static string AsString(this object target)
        {
            return ReferenceEquals(target, null) ? null : string.Format("{0}", target);
        }

        /// <summary>
        /// Cast an object to the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to cast.</typeparam>
        /// <param name="obj">The object to be cast</param>
        /// <returns>The object casted to the given type, or the default type value.</returns>
        public static T CastAs<T>(this object obj) where T : class, new()
        {
            if (obj is T)
                return (T)obj;
            return default(T);
        }

        /// <summary>
        /// Perform a deep copy of an object.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        /// <see cref="http://stackoverflow.com/a/519512/1218281"/>
        public static T DeepClone<T>(this T source)
        {
            if (!typeof(T).IsSerializable) //Make sure type is serializable
                throw new ArgumentException("The type must be serializable.", "source");

            if (Object.ReferenceEquals(source, null)) //Check if the source is null
                return default(T);

            using (MemoryStream stream = new MemoryStream()) //Clone the source
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
