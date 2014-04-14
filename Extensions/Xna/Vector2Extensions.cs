using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Cyral.Extensions.Xna
{
    public static class Vector2Extensions
    {
        /// <summary>
        /// Creates a new Vector2 from a Point.
        /// </summary>
        public static Vector2 FromPoint(Point p)
        {
            return new Vector2(p.X, p.Y);
        }

        /// <summary>
        /// Transforms a Vector2 into a Point.
        /// </summary>
        public static Point ToPoint(this Vector2 vector)
        {
            return new Point((int)vector.X,(int)vector.Y);
        }

        /// <summary>
        /// Rounds a vector's X and Y values to the nearest integer.
        /// </summary>
        /// <param name="vector">Vector2 to round.</param>
        /// <returns>A Vector2 with integer X and Y values.</returns>
        public static Vector2 Round(this Vector2 vector)
        {
            vector.X = (int)Math.Round(vector.X);
            vector.Y = (int)Math.Round(vector.Y);
            return vector;
        }

        /// <summary>
        /// Rotates a vector around a center point.
        /// </summary>
        /// <param name="point">Vector position to rotate.</param>
        /// <param name="origin">Point to rotate around.</param>
        /// <param name="rotation">Rotation to be applied.</param>
        /// <returns>A Vector2 that has been rotated around a center point.</returns>
        public static Vector2 RotateAboutOrigin(this Vector2 point, Vector2 origin, float rotation)
        {
            return Vector2.Transform(point - origin, Matrix.CreateRotationZ(rotation)) + origin;
        } 
    }
}
