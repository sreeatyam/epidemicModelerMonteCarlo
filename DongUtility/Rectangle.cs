﻿using System;
using System.Collections.Generic;
using static DongUtility.UtilityFunctions;

namespace DongUtility
{
    /// <summary>
    /// A simple, non-rotated rectangle in two dimensions
    /// Should be replaced by Geometry project
    /// </summary>
    public struct Rectangle : IEquatable<Rectangle>
    {
        public Vector2D Center { get; set; }

        public double Width { get; set; }
        public double Height { get; set; }

        // The maximum and minimum values in x and y

        public double MinY => Center.Y - Height / 2;
        public double MaxY => Center.Y + Height / 2;
        public double MinX => Center.X - Width / 2;
        public double MaxX => Center.X + Width / 2;

        // The corners of the rectangle

        public Vector2D MinXMinY => new Vector2D(MinX, MinY);
        public Vector2D MaxXMinY => new Vector2D(MaxX, MinY);
        public Vector2D MinXMaxY => new Vector2D(MinX, MaxY);
        public Vector2D MaxXMaxY => new Vector2D(MaxX, MaxY);

        public Rectangle(Vector2D center, double width, double height)
        {
            Center = center;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Returns whether the rectangle contains a given point
        /// </summary>
        public bool Contains(Vector2D point)
        {
            return point.X > MinX && point.X < MaxX && point.Y > MinY && point.Y < MaxY;
        }

        /// <summary>
        /// Returns whether two rectangles overlap
        /// </summary>
        public bool Overlaps(Rectangle other)
        {
            // Either one edge or the other of Other is in this range, or the entirety (and thus the center) of this range lies in Other
            return OverlapsX(other) && OverlapsY(other);
        }

        /// <summary>
        /// Returns whether two rectangles overlap in the x direction
        /// </summary>
        public bool OverlapsX(Rectangle other)
        {
            return Between(other.MinX, MinX, MaxX) || Between(other.MaxX, MinX, MaxX) || Between(Center.X, other.MinX, other.MaxX);
        }

        /// <summary>
        /// Returns whether two rectangles overlap in the y direction
        /// </summary>
        public bool OverlapsY(Rectangle other)
        {
            return Between(other.MinY, MinY, MaxY) || Between(other.MaxY, MinY, MaxY) || Between(Center.Y, other.MinY, other.MaxY);
        }

        public override bool Equals(object? obj)
        {
            return obj is Rectangle rectangle && Equals(rectangle);
        }

        public bool Equals(Rectangle other)
        {
            return EqualityComparer<Vector2D>.Default.Equals(Center, other.Center) &&
                   Width == other.Width &&
                   Height == other.Height;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Center, Width, Height);
        }

        static public bool operator==(Rectangle r1, Rectangle r2)
        {
            return r1.Center == r2.Center && r1.Width == r2.Width && r1.Height == r2.Height;
        }

        static public bool operator!=(Rectangle r1, Rectangle r2)
        {
            return !(r1 == r2);
        }
    }
}
