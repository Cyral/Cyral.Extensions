using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Cyral.Extensions.Xna
{
    public static class RectangleExtensions
    {
        /// <summary>
        /// Constructs a rectangle from a Point's X and Y position
        /// </summary>
        public static Rectangle FromPoint(Point p, int width = 0, int height = 0)
        {
            return new Rectangle(p.X, p.Y, width, height);
        }

        /// <summary>
        /// Constructs a rectangle from a Vector2's X and Y position
        /// </summary>
        public static Rectangle FromVector2(Vector2 v, int width = 0, int height = 0)
        {
            return new Rectangle((int)Math.Round(v.X), (int)Math.Round(v.Y), width, height);
        }
    }
}
