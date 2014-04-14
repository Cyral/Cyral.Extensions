using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyral.Extensions
{
    public static class EnumerableExtensions
    {
        private static Random random = new Random(); //Keep out of methods to prevent same seeds

        ///<summary>
        ///	Tests if the array is null or empty.
        ///</summary>
        ///<param name="source">Source array to test.</param>
        ///<returns>True if the array is null or has a length of 0, false otherwise.</returns>
        public static bool IsNullOrEmpty(this Array source)
        {
            return source == null || source.Length == 0;
        }

        /// <summary>
        /// Executes the specified action on each element in the source collection.
        /// </summary>
        /// <typeparam name="T">Type of the objects in the collection.</typeparam>
        /// <param name="source">The collection to apply the action to.</param>
        /// <param name="action">The action to repeat on each element in the source.</param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (action == null) throw new ArgumentNullException("action");

            foreach (T item in source)
            {
                action(item);
            }
        }

        /// <summary>
        /// Randomizes the order of elements in a collection.
        /// </summary>
        /// <typeparam name="T">Type of the objects in the collection.</typeparam>
        /// <param name="list">Collection to shuffle.</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            if (list == null) throw new ArgumentNullException("list");

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
