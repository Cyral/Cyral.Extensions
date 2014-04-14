using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Cyral.Extensions.Xna
{
    public static class MouseStateExtensions
    {
        /// <summary>
        /// Gets the position of the cursor as a Point value.
        /// </summary>
        public static Point GetPositionPoint(this MouseState ms)
        {
            return new Point(ms.X, ms.Y);
        }

        /// <summary>
        /// Gets the position of the cursor as a Vector2 value.
        /// </summary>
        public static Vector2 GetPositionVector(this MouseState ms)
        {
            return new Vector2(ms.X, ms.Y);
        }
    }
}
