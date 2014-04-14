using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Cyral.Extensions
{

    /// <summary>
    /// Extension methods for the enum data type
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Tests to see if a constant with the specified value exists in the enumeration type.
        /// </summary>
        /// <typeparam name="T">Type of <c>Enum</c></typeparam>
        /// <param name="value">Constant to check.</param>
        /// <returns>True of the constant exists in the enumeration, false otherwise</returns>
        public static bool IsValid<T>(this T value)
        {
            if (value == null) throw new ArgumentNullException("value");
            return Enum.IsDefined(value.GetType(), value);
        }

        /// <summary>
        /// Gets the Description attribute from an enum constant.
        /// </summary>
        /// <example>
        /// 	<code>
        ///         public enum States
        ///         {
        ///             California,
        ///             [Description("New Mexico")]
        ///             NewMexico,
        ///             Washington
        ///         }
        ///         GetEnumDescription(States.NewMexico) will return "New Mexico"
        /// 	</code>
        /// </example>
        /// <param name="value">Enum constant</param>
        /// <returns>The <c>DescriptionAttribute</c> of the enum constant.</returns>
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo info = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return (attributes != null && attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

    }
}
