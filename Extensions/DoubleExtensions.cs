using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyral.Extensions
{
    public static class DoubleExtensions
    {
        /// <summary>
        /// Finds whether or not a <c>double</c> value is between two other numbers.
        /// </summary>
        /// <param name="num">Number to test.</param>
        /// <param name="lower">Lower number.</param>
        /// <param name="upper">Upper number.</param>
        /// <param name="inclusive">If the check is inclusive.</param>
        /// <returns>True if the value was between the upper and lower numbers, false otherwise.</returns>
        public static bool IsBetween(this double num, double lower, double upper, bool inclusive = false)
        {
            return inclusive
                ? lower <= num && num <= upper
                : lower < num && num < upper;
        }

        /// <summary>
        /// Rounds a number to the nearest specified value. (Ex: Round 7.3 to the nearest 10th equals 10)
        /// </summary>
        /// <param name="number">Number to round</param>
        /// <param name="nearest">Nearest number to round to</param>
        /// <returns>The number rounded to the nearest specified value</returns>
        public static double RoundTo(this double number, double nearest)
        {
            return (Math.Round(number / nearest)) * nearest;
        }

        /// <summary>
        /// Checks if a number is divisible by a certain factor.
        /// </summary>
        /// <param name="number">Number to check.</param>
        /// <param name="factor">Factor to use.</param>
        /// <returns>True if the number is divisible by the factor, false otherwise</returns>
        public static bool IsDivisble(double number, double factor)
        {
            return (number % factor) == 0;
        }
    }
}
