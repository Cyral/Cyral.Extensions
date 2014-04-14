using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyral.Extensions
{
    public static class IntExtensions
    {
        /// <summary>
        /// Finds whether or not an <c>int</c> value is between two other numbers.
        /// </summary>
        /// <param name="num">Number to test.</param>
        /// <param name="lower">Lower number.</param>
        /// <param name="upper">Upper number.</param>
        /// <param name="inclusive">If the check is inclusive.</param>
        /// <returns>True if the value was between the upper and lower numbers, false otherwise.</returns>
        public static bool IsBetween(this int num, int lower, int upper, bool inclusive = false)
        {
            return inclusive
                ? lower <= num && num <= upper
                : lower < num && num < upper;
        }

        /// <summary>
        /// Determines if the specified number is even.
        /// </summary>      
        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }

        /// <summary>
        /// Determines if the specified number is odd.
        /// </summary>
        public static bool IsOdd(this int number)
        {
            return !number.IsEven();
        }

        /// <summary>
        /// Checks if a number is divisible by a certain factor.
        /// </summary>
        /// <param name="number">Number to check.</param>
        /// <param name="factor">Factor to use.</param>
        /// <returns>True if the number is divisible by the factor, false otherwise</returns>
        public static bool IsDivisble(int number, int factor)
        {
            return (number % factor) == 0;
        }

        /// <summary>
        /// Rounds a number to the nearest specified value. (Ex: Round 7 to the nearest 10th equals 10)
        /// </summary>
        /// <param name="number">Number to round</param>
        /// <param name="nearest">Nearest number to round to</param>
        /// <returns>The number rounded to the nearest specified value</returns>
        public static int RoundTo(this int number, int nearest)
        {
            return ((int)Math.Round(number / (float)nearest)) * nearest;
        }

        /// <summary>
        /// Converts an integer into a Roman numeral (Ex: 8 to VIII)
        /// </summary>
        /// <param name="number">Integer to convert.</param>
        /// <returns>A string containing a Roman numeral</returns>
        /// <see cref="http://stackoverflow.com/a/11749642/1218281"/>
        public static string ToRomanNumeral(this int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("Value must be between 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRomanNumeral(number - 1000);
            if (number >= 900) return "CM" + ToRomanNumeral(number - 900);
            if (number >= 500) return "D" + ToRomanNumeral(number - 500);
            if (number >= 400) return "CD" + ToRomanNumeral(number - 400);
            if (number >= 100) return "C" + ToRomanNumeral(number - 100);
            if (number >= 90) return "XC" + ToRomanNumeral(number - 90);
            if (number >= 50) return "L" + ToRomanNumeral(number - 50);
            if (number >= 40) return "XL" + ToRomanNumeral(number - 40);
            if (number >= 10) return "X" + ToRomanNumeral(number - 10);
            if (number >= 9) return "IX" + ToRomanNumeral(number - 9);
            if (number >= 5) return "V" + ToRomanNumeral(number - 5);
            if (number >= 4) return "IV" + ToRomanNumeral(number - 4);
            if (number >= 1) return "I" + ToRomanNumeral(number - 1);
            throw new ArgumentOutOfRangeException(string.Format("Could not convert {0} to a Roman numeral.", number));
        }

        /// <summary>
        /// Adds an ordinal to the end of a number (Ex: 5 becomes 5th)
        /// </summary>
        /// <param name="number">Intiger to add ordinal to.</param>
        /// <returns>A string with the added ordinal.</returns>
        /// <see cref="http://stackoverflow.com/a/20175/1218281"/>
        public static string AppendOrdinal(this int number)
        {
            if (number <= 0) return number.ToString();
            switch (number % 100)
            {
                case 11:
                case 12:
                case 13:
                    return number + "th";
            }
            switch (number % 10)
            {
                case 1:
                    return number + "st";
                case 2:
                    return number + "nd";
                case 3:
                    return number + "rd";
                default:
                    return number + "th";
            }
        }
    }
}