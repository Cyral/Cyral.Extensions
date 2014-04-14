using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Cyral.Extensions.Xna
{
    /// <summary> 
    /// Represents a 2D circle. 
    /// </summary> 
    public struct Circle
    {
        public static Circle Empty { get { return new Circle(0, 0, 0); } }

        private Vector2 v;
        private Vector2 direction;
        private float distanceSquared;

        /// <summary> 
        /// Center position of the circle. 
        /// </summary> 
        public Vector2 Center { get; set; }

        /// <summary> 
        /// Radius of the circle. 
        /// </summary> 
        public float Radius { get; set; }

        /// <summary> 
        /// Constructs a new circle. 
        /// </summary> 
        public Circle(Vector2 position, float radius) : this()
        {
            this.distanceSquared = 0f;
            this.direction = Vector2.Zero;
            this.v = Vector2.Zero;
            this.Center = position;
            this.Radius = radius;
        }

        /// <summary> 
        /// Constructs a new circle. 
        /// </summary> 
        public Circle(int x, int y, float radius) : this(new Vector2(x,y), radius)
        {
        }

        /// <summary> 
        /// Determines if a circle intersects a rectangle. 
        /// </summary> 
        /// <returns>True if the circle and rectangle overlap. False otherwise.</returns> 
        public bool Intersects(Rectangle rectangle)
        {
            this.v = new Vector2(MathHelper.Clamp(Center.X, rectangle.Left, rectangle.Right),
                                    MathHelper.Clamp(Center.Y, rectangle.Top, rectangle.Bottom));

            this.direction = Center - v;
            this.distanceSquared = direction.LengthSquared();

            return ((distanceSquared > 0) && (distanceSquared < Radius * Radius));
        }

        /// <summary> 
        /// Determines if a circle contains a Point
        /// </summary> 
        /// <returns>True if the circle and Point overlap. False otherwise.</returns> 
        public bool Contains(Point p)
        {
            this.v = new Vector2(p.X,p.Y);

            this.direction = Center - v;
            this.distanceSquared = direction.LengthSquared();

            return ((distanceSquared > 0) && (distanceSquared < Radius * Radius));
        }

        /// <summary> 
        /// Determines if a circle contains a Vector2
        /// </summary> 
        /// <returns>True if the circle and Vector2 overlap. False otherwise.</returns> 
        public bool Contains(Vector2 vector)
        {
            return Contains(new Point((int)vector.X,(int)vector.Y));
        }
    }
}
 