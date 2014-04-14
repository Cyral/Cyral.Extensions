using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyral.Extensions
{
    public static class RandomExtensions
    {
        /// <summary>
        /// Returns a random element from the input.
        /// </summary>
        /// <typeparam name="T">Type of object in the input.</typeparam>
        /// <param name="random">Random generator to use.</param>
        /// <param name="input">Input objects.</param>
        /// <returns>Random element from the input.</returns>
        public static T OneOf<T>(this Random random, params T[] input)
        {
            return input[random.Next(input.Length)];
        }

        #region Next
        /// <summary>
        /// Returns a random number between min and max
        /// </summary>
        public static decimal NextDecimal(this Random random, decimal min, decimal max)
        {
            return min + (decimal)random.NextDouble() * (max - min);
        }

        /// <summary>
        /// Returns a random number between 0.0 and 1.0
        /// </summary>
        public static decimal NextDecimal(this Random random)
        {
            return (decimal)random.NextDouble();
        }

        /// <summary>
        /// Returns a random number between min and max
        /// </summary>
        public static double NextDouble(this Random random, double min, double max)
        {
            return min + random.NextDouble() * (max - min);
        }

        /// <summary>
        /// Returns a random number between min and max
        /// </summary>
        public static float NextFloat(this Random random, float min, float max)
        {
            return min + (float)random.NextDouble() * (max - min);
        }

        /// <summary>
        /// Returns a random number between 0.0 and 1.0
        /// </summary>
        public static float NextFloat(this Random random)
        {
            return (float)random.NextDouble();
        }

        /// <summary>
        /// Generates a random boolean value, true or false
        /// </summary>
        /// <param name="random">A random instance</param>
        /// <returns>A random boolean value, true or false</returns>
        public static bool NextBoolean(this Random random)
        {
            return random.Next(2) == 0;
        }
        #endregion

        /// <summary>
        /// Numbers near the average number are generated most often
        /// In example: doing Deviation(0,10,5) Will generate 5 most of the time and 0 and 10
        /// the least, as it is "rare" random, 4 and 6 will be quite common, but not 1 and 9
        /// </summary>
        /// <param name="min">Minimum Value, Unlikely</param>
        /// <param name="max">Maximum Value, Unlikely</param>
        /// <param name="avg">Average Value, Common</param>
        [Obsolete("Very old method, should be rewritten. Left in here as an idea.")]
        public static int Deviation(this Random random, int min, int max, int avg)
        {
            //Create a new list, This will store all the values
            List<int> list = new List<int>();
            //Loop from the minimum number, to the average number
            for (int a = min; a <= avg; a++)
            {
                //Decide how many times to add the number to the list, based on how close it is to the average number
                for (int times = 1; times <= a - min + 1; times++)
                    list.Add(a);
            }
            //Now we go down, From maximum number to average number
            for (int a = max; a > avg; a--)
            {
                //Decide how many times to add the number to the list, based on how close it is to the average number
                for (int times = 1; times <= max - a + 1; times++)
                    list.Add(a);
            }
            //Select a random number from the list and return it, because numbers closer to the average are inputed more in the list
            //this will cause them to be more common
            return list[random.Next(0, list.Count)];
        } 
    }
}
