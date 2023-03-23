﻿using DongUtility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry.Geometry3D
{
    /// <summary>
    /// A simple (not necessarily regular) tetrahedron.
    /// All four points are allowed to be coplanar - beware of strange results!
    /// </summary>
    public class Tetrahedron
    {
        /// <summary>
        /// An array of four points, the vertices
        /// </summary>
        public Point[] Points { get; }

        public Tetrahedron(Point point1, Point point2, Point point3, Point point4)
        {
            Points = new Point[4] { point1, point2, point3, point4 };
        }

        private Triangle[] triangles;
        /// <summary>
        /// The four faces of the tetrahedron
        /// </summary>
        public Triangle[] Triangles
        {
            get
            {
                if (triangles == null)
                {
                    CreateTriangles();
                }
                return triangles;
            }
        }

        /// <summary>
        /// Returns whether a given point lies within the tetrahedron
        /// </summary>
        public bool LiesInside(Point point)
        {
            return Triangles[0].ContainingPlane.SameHalfSpace(point, Points[3])
                && Triangles[1].ContainingPlane.SameHalfSpace(point, Points[2])
                && Triangles[2].ContainingPlane.SameHalfSpace(point, Points[1])
                && Triangles[3].ContainingPlane.SameHalfSpace(point, Points[0]);
        }

        private void CreateTriangles()
        {
            triangles = new Triangle[4] {new Triangle(Points[0], Points[1], Points[2]),
                new Triangle(Points[0], Points[1], Points[3]),
                new Triangle(Points[0], Points[2], Points[3]),
                new Triangle(Points[1], Points[2], Points[3])};
        }

        /// <summary>
        /// Returns whether this tetrahedron has any volume of overlap with another
        /// </summary>
        public bool BulkOverlap(Tetrahedron other)
        {
            foreach (var point in Points)
            {
                if (other.LiesInside(point))
                {
                    return true;
                }
            }
            foreach (var point in other.Points)
            {
                if (LiesInside(point))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the center of mass, assuming uniform mass distribution
        /// </summary>
        public Point CenterOfMass
        {
            get
            {
                // From https://math.stackexchange.com/questions/1592128/finding-center-of-mass-for-tetrahedron
                var sum = Points[0].PositionVector() + Points[1].PositionVector() + Points[2].PositionVector() + Points[3].PositionVector();
                return (.25 * sum).ToPoint();
            }
        }

        public double Volume
        {
            // Formula from Wikipedia, using Points[0] as a, Points[1] as b, etc.
            get
            {
                var crossProduct = Vector.Cross(Points[1] - Points[3], Points[2] - Points[3]);
                var dotProduct = Vector.Dot(Points[0] - Points[3], crossProduct);
                return Math.Abs(dotProduct) / 6;
            }
        }
    }
}
