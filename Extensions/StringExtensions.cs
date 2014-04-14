using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Cyral.Extensions
{
    public static class StringExtensions
    {
        #region Fields
        private static readonly char[] unsafeFileNameChars = { '<', '>', ':', '"', '/', '\\', '|', '?', '*' };
        private static readonly Regex urlRegex = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
        private static readonly Regex emailRegex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        #endregion

        #region To X Methods
        /// <summary>
        /// Parses a string into an Enum
        /// </summary>
        /// <typeparam name="T">The type of the Enum</typeparam>
        /// <param name="value">String value to parse</param>
        /// <returns>The Enum corresponding to the stringExtensions</returns>
        public static T ToEnum<T>(this string value)
        {
            return ToEnum<T>(value, false);
        }

        /// <summary>
        /// Parses a string into an Enum
        /// </summary>
        /// <typeparam name="T">The type of the Enum</typeparam>
        /// <param name="value">String value to parse</param>
        /// <param name="ignorecase">Ignore the case of the string being parsed</param>
        /// <returns>The Enum corresponding to the stringExtensions</returns>
        public static T ToEnum<T>(this string value, bool ignorecase)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            value = value.Trim();

            if (value.Length == 0)
                throw new ArgumentNullException("Must specify valid information for parsing in the string.", "value");

            Type t = typeof(T);
            if (!t.IsEnum)
                throw new ArgumentException("Type provided must be an Enum.", "T");

            return (T)Enum.Parse(t, value, ignorecase);
        }

        /// <summary>
        /// Converts a string into an int value.
        /// </summary>
        public static int ToInteger(this string value, int defaultvalue)
        {
            return (int)ToDouble(value, defaultvalue);
        }

        /// <summary>
        /// Converts a string into an int value.
        /// </summary>
        public static int ToInteger(this string value)
        {
            return ToInteger(value, 0);
        }

        /// <summary>
        /// Converts a string into a double value.
        /// </summary>
        public static double ToDouble(this string value, double defaultvalue)
        {
            double result;
            if (double.TryParse(value, out result))
            {
                return result;
            }
            else return defaultvalue;
        }

        /// <summary>
        /// Converts a string into a double value.
        /// </summary>
        public static double ToDouble(this string value)
        {
            return ToDouble(value, 0);
        }

        /// <summary>
        /// Converts a string value to <c>Boolean</c> value, supports "T" and "F" conversions.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <returns>A bool based on the string value</returns>
        public static bool? ToBoolean(this string value)
        {
            if (string.Compare("T", value, true) == 0) return true;
            else if (string.Compare("F", value, true) == 0) return false;
            bool result;
            if (bool.TryParse(value, out result)) return result;
            else return null;
        }
        #endregion

        /// <summary>
        /// Clamps a strings character count to a specified length.
        /// </summary>
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        /// <summary>
        /// Uses <c>Regex.Replace(str, @"\s+", "");</c> to remove whitespace from a string.
        /// </summary>
        public static string RemoveWhitespace(this string str)
        {
            return Regex.Replace(str, @"\s+", "");
        }

        /// <summary>
        /// Adds spaces before capitals in a string.
        /// </summary>
        public static string AddSpacesToSentence(this string text, bool preserveAcronyms = true)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                    if ((text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) ||
                        (preserveAcronyms && char.IsUpper(text[i - 1]) &&
                         i < text.Length - 1 && !char.IsUpper(text[i + 1])))
                        newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }

        /// <summary>
        /// Repeats the specified string value as provided by the repeat count.
        /// </summary>
        /// <param name ="value">The original string.</param>
        /// <param name ="iterations">The repeat count.</param>
        /// <returns>The repeated string</returns>
        public static string Repeat(this string value, int iterations)
        {
            if (value.Length == 1)
                return new string(value[0], iterations);

            var sb = new StringBuilder(iterations * value.Length);
            while (iterations-- > 0)
                sb.Append(value);
            return sb.ToString();
        }
        /// <summary>
        /// Tests whether the contents of a string is a numeric value
        /// </summary>
        /// <param name ="value">String to check</param>
        /// <returns>
        /// Boolean indicating whether or not the string contents are numeric
        /// </returns>
        public static bool IsNumeric(this string value)
        {
            float output;
            return float.TryParse(value, out output);
        }
        /// <summary>Convert text's case to a title case with the current culture</summary>
        /// <remarks>UppperCase characters is the source string after the first of each word are lowered, unless the word is exactly 2 characters</remarks>
        public static string ToTitleCase(this string value)
        {
            return ToTitleCase(value, System.Globalization.CultureInfo.CurrentCulture);
        }

        /// <summary>Convert text's case to a title case</summary>
        /// <param name ="culture">Culture to use</param>
        /// <remarks>UppperCase characters is the source string after the first of each word are lowered, unless the word is exactly 2 characters</remarks>
        public static string ToTitleCase(this string value, CultureInfo culture)
        {
            return culture.TextInfo.ToTitleCase(value);
        }

        /// <summary>
        /// Uses simple english rules to convert a string to it's plural form.
        /// </summary>
        /// <param name="singular">The singular form of the string</param>
        /// <returns>The pluralized form of the string</returns>
        public static string ToPlural(this string singular)
        {
            // Multiple words in the form A of B : Apply the plural to the first word only (A)
            int index = singular.LastIndexOf(" of ");
            if (index > 0) return (singular.Substring(0, index)) + singular.Remove(0, index).ToPlural();

            // single Word rules
            //sibilant ending rule
            if (singular.EndsWith("sh")) return singular + "es";
            if (singular.EndsWith("ch")) return singular + "es";
            if (singular.EndsWith("us")) return singular + "es";
            if (singular.EndsWith("ss")) return singular + "es";
            //-ies rule
            if (singular.EndsWith("y")) return singular.Remove(singular.Length - 1, 1) + "ies";
            // -oes rule
            if (singular.EndsWith("o")) return singular.Remove(singular.Length - 1, 1) + "oes";
            // -s suffix rule
            return singular + "s";
        }

        /// <summary>
        /// Finds the amount of words in a string, using spaces and punctuation as splitters
        /// </summary>
        /// <param name="str">Input string</param>
        /// <returns>The word count</returns>
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ', '.', '?', '!' },
                StringSplitOptions.RemoveEmptyEntries).Length;
        }

        /// <summary>
        /// Capitalizes the first letter in the word
        /// </summary>
        /// <param name="word"></param>
        /// <returns>The string with an uppercase first letter</returns>
        public static string Capitalize(this string word)
        {
            return word[0].ToString().ToUpper() + word.Substring(1);
        }

        /// <summary>
        /// Reverses a String
        /// </summary>
        /// <param name="input">The string to reverse</param>
        /// <returns>The reversed String</returns>
        public static string Reverse(this string input)
        {
            char[] array = input.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        /// <summary>
        /// Determines whether a string is a valid URL. (For use with http and https)
        /// </summary>
        public static bool IsValidUrl(this string text)
        {
            return urlRegex.IsMatch(text);
        }
        /// <summary>
        /// Determines whether a string is a valid email address
        /// </summary>
        public static bool IsValidEmailAddress(this string email)
        {
            return emailRegex.IsMatch(email);
        }

        /// <summary>
        /// Indicates if the string can be used as a file name.
        /// </summary>
        public static bool IsFileNameSafe(this string text)
        {

            foreach (char symbol in unsafeFileNameChars)
            {
                foreach (char c in text)
                    if (symbol == c) return false;
            }

            return true;
        }

        /// <summary>
        /// Returns the right portion of the string for the specified length.
        /// </summary>
        public static string Right(this string str, int length)
        {
            if (length <= 0 || str.Length == 0) return string.Empty; //If the string is empty
            if (str.Length <= length) return str; //If the specified length is greater than the size of the string
            return str.Substring(str.Length - length, length);
        }

        /// <summary>
        /// Returns the left portion of the string for the specified length.
        /// </summary>
        public static string Left(this string str, int length)
        {
            if (length <= 0 || str.Length == 0) return string.Empty; //If the string is empty
            if (str.Length <= length) return str; //If the specified length is greater than the size of the string
            return str.Substring(0, length);
        }

        /// <summary>
        /// Indicates if the specified string is equal to the string to test, while ignoring the case of both.
        /// </summary>
        public static bool EqualsIgnoreCase(this string a, string b)
        {
            return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Overwrites a string value with a new string value, preserving the old string characters if the new string is shorter than it.
        /// </summary>
        public static string Overwrite(this string str, int startIndex, string newStringValue)
        {
            return str.Remove(startIndex, newStringValue.Length).Insert(startIndex, newStringValue);
        }

        /// <summary>
        /// Indicates whether the current string matches the supplied wildcard pattern.  Behaves the same
        /// as VB's "Like" Operator.
        /// </summary>
        /// <param name="str">The string instance where the extension method is called</param>
        /// <param name="wildcardPattern">The wildcard pattern to match.  Syntax matches VB's Like operator.</param>
        /// <returns>True if the string matches the supplied pattern, false otherwise.</returns>
        /// <remarks>See http://msdn.microsoft.com/en-us/library/swf8kaxw(v=VS.100).aspx </remarks>
        public static bool IsLike(this string str, string wildcardPattern)
        {
            if (str == null || String.IsNullOrEmpty(wildcardPattern)) return false;
            // turn into regex pattern, and match the whole string with ^$
            var regexPattern = "^" + Regex.Escape(wildcardPattern) + "$";

            // add support for ?, #, *, [], and [!]
            regexPattern = regexPattern.Replace(@"\[!", "[^")
                                       .Replace(@"\[", "[")
                                       .Replace(@"\]", "]")
                                       .Replace(@"\?", ".")
                                       .Replace(@"\*", ".*")
                                       .Replace(@"\#", @"\d");

            var result = false;
            try
            {
                result = Regex.IsMatch(str, regexPattern);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(String.Format("Invalid pattern: {0}", wildcardPattern), ex);
            }
            return result;
        }
    }
}
