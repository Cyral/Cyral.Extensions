using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Cyral.Extensions.Xna
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Converts a HSV color to an RGB (XNA) color
        /// </summary>
        /// <remarks>
        /// Hue varies from 0 to 360
        /// Saturation and Value vary from 0 to 255
        /// </remarks>
        /// <see cref="http://stackoverflow.com/a/1626232/1218281"/>
        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return FromARGB(255, v, t, p);
            else if (hi == 1)
                return FromARGB(255, q, v, p);
            else if (hi == 2)
                return FromARGB(255, p, v, t);
            else if (hi == 3)
                return FromARGB(255, p, q, v);
            else if (hi == 4)
                return FromARGB(255, t, p, v);
            else
                return FromARGB(255, v, p, q);
        }

        #region From RGB
        /// <summary>
        /// Creates a color from a Red, Green, and Blue value.
        /// Values are from 0 - 255
        /// </summary>
        public static Color FromRGB(int r, int g, int b)
        {
            return new Color((byte)r, (byte)g, (byte)b);
        }

        /// <summary>
        /// Creates a color from a Red, Green, and Blue value.
        /// Values are from 0f - 1f
        /// </summary>
        public static Color FromRGB(float r, float g, float b)
        {
            return new Color(r,g,b);
        }

        /// <summary>
        /// Creates a color from an Alpha, Red, Green, and Blue value.
        /// Values are from 0 - 255
        /// </summary>
        public static Color FromARGB(int a, int r, int g, int b)
        {
            return new Color((byte)r, (byte)g, (byte)b, (byte)a);
        }

        /// <summary>
        /// Creates a color from an Alpha, Red, Green, and Blue value.
        /// Values are from 0f - 1f
        /// </summary>
        public static Color FromARGB(float a, float r, float g, float b)
        {
            return new Color(r, g, b, a);
        }
        #endregion

        /// <summary>
        /// Ajusts the alpha value of a color (transparency)
        /// </summary>
        /// <param name="color">Existing Color</param>
        /// <param name="alpha">Alpha (0 - 1f)</param>
        public static Color Alpha(this Color color, float alpha)
        {
            return new Color((color.R / 255f) * alpha,(color.G / 255f) * alpha,(color.B / 255f) * alpha,alpha);
        }

        /// <summary>
        /// Creates an ARGB hex string representation of the <see cref="Color"/> value.
        /// </summary>
        /// <param name="color">The <see cref="Color"/> value to parse.</param>
        /// <param name="includeHash">Indicates whether to include the hash mark (#) character in the string.</param>
        /// <returns>A hex string representation of the specified <see cref="Color"/> value.</returns>
        public static string ToHex(this Color color, bool includeHash)
        {
            string[] argb = {
                color.A.ToString("X2"),
                color.R.ToString("X2"),
                color.G.ToString("X2"),
                color.B.ToString("X2"),
            };
            return (includeHash ? "#" : string.Empty) + string.Join(string.Empty, argb);
        }

        /// <summary>
        /// Creates a <see cref="Color"/> value from an ARGB or RGB hex string.  The string may
        /// begin with or without the hash mark (#) character.
        /// </summary>
        /// <param name="hexString">The ARGB hex string to parse.</param>
        /// <returns>
        /// A <see cref="Color"/> value as defined by the ARGB or RGB hex string.
        /// </returns>
        /// <exception cref="InvalidOperationException">Thrown if the string is not a valid ARGB or RGB hex value.</exception>
        public static Color FromHex(this string hexString)
        {
            if (hexString.StartsWith("#"))
                hexString = hexString.Substring(1);
            uint hex = uint.Parse(hexString, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            Color color = Color.White;
            if (hexString.Length == 8)
            {
                color.A = (byte)(hex >> 24);
                color.R = (byte)(hex >> 16);
                color.G = (byte)(hex >> 8);
                color.B = (byte)(hex);
            }
            else if (hexString.Length == 6)
            {
                color.R = (byte)(hex >> 16);
                color.G = (byte)(hex >> 8);
                color.B = (byte)(hex);
            }
            else
            {
                throw new InvalidOperationException("Invald hex representation of an ARGB or RGB color value.");
            }
            return color;
        }
    }
}
