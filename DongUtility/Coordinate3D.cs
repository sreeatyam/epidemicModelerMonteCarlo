﻿using System;

namespace DongUtility
{
    /// <summary>
    /// A simple three-dimensional integer coordinate
    /// </summary>
    public struct Coordinate3D : IEquatable<Coordinate3D>
    {
        public Coordinate3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Coordinate3D coord && Equals(coord);
        }

        public bool Equals(Coordinate3D other)
        {
            return X == other.X &&
                   Y == other.Y &&
                   Z == other.Z;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        /// <summary>
        /// Converts the coordinate to a vector (of doubles)
        /// </summary>
        public Vector ToVector()
        {
            return new Vector(X, Y, Z);
        }

        static public bool operator ==(Coordinate3D lhs, Coordinate3D rhs)
        {
            return lhs.Equals(rhs);
        }

        static public bool operator !=(Coordinate3D lhs, Coordinate3D rhs)
        {
            return !lhs.Equals(rhs);
        }

        public override string ToString()
        {
            return "[ " + X + ", " + Y + ", " + Z + " ]";
        }
    }
}

