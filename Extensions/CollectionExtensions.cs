using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyral.Extensions
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Tests if the collection is empty.
        /// </summary>
        /// <param name="source">The collection to test.</param>
        /// <returns>True if the collection is null or has a count of 0, false otherwise.</returns>
        public static bool IsNullOrEmpty(this ICollection source)
        {
            return source == null || source.Count == 0;
        }

        /// <summary>
        /// Adds a value uniquely to to a collection and returns a value whether the value was added or not.
        /// (If the collection already contains the value(s), they will not be added)
        /// </summary>
        /// <typeparam name="T">The generic collection value type.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="value">The value to be added.</param>
        /// <returns>Indicates whether the value was added or not.</returns>
        /// <example>
        /// 	<code>
        /// 		list.AddUnique(1); // returns true;
        /// 		list.AddUnique(1); // returns false the second time;
        /// 	</code>
        /// </example>
        public static bool AddUnique<T>(this ICollection<T> collection, T value)
        {
            bool contains = collection.Contains(value);
            if (!contains)
                collection.Add(value);
            return contains;
        }

        /// <summary>
        /// Adds a range of values uniquely to a collection and returns the amount of values added.
        /// (If the collection already contains the value(s), they will not be added)
        /// </summary>
        /// <typeparam name="T">The generic collection value type.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="values">The values to be added.</param>
        /// <returns>The amount of values that were added.</returns>
        public static int AddRangeUnique<T>(this ICollection<T> collection, IEnumerable<T> values)
        {
            var count = 0;
            foreach (var value in values)
            {
                if (collection.AddUnique(value))
                    count++;
            }
            return count;
        }
    }
}
