using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Cyral.Extensions.Xna
{
    public static class PointExtensions
    {
        /// <summary>
        /// Creates a new Point from a Vector2
        /// </summary>
        public static Point FromPoint(Vector2 vector)
        {
            return new Point((int)vector.X,(int)vector.Y);
        }

        /// <summary>
        /// Transforms a Point into a Vector2
        /// </summary>
        public static Vector2 ToVector2(this Point p)
        {
            return new Vector2(p.X, p.Y);
        }
    }
}
