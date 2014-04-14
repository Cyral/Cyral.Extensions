using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyral.Extensions
{
    public static class BooleanExtensions
    {
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation (either "Yes" or "No").
        /// </summary>
        /// <param name="boolean">Bool value to base the conversion on</param>
        /// <returns>"Yes" or "No"</returns>
        public static string ToYesNoString(this Boolean boolean)
        {
            return boolean ? "Yes" : "No";
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation (either "T" or "F").
        /// </summary>
        /// <param name="boolean">Bool value to base the conversion on</param>
        /// <returns>"T" or "F"</returns>
        public static string ToTFString(this Boolean boolean)
        {
            return boolean ? "T" : "F";
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent binary representation (either "1" or "0").
        /// </summary>
        /// <param name="boolean">Bool value to base the conversion on</param>
        /// <returns>1 or 0</returns>
        public static int ToBinary(this Boolean boolean)
        {
            return boolean ? 1 : 0;
        }
    }
}
