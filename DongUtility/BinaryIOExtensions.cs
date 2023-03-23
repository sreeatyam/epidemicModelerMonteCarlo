﻿using System.Drawing;
using System.IO;

namespace DongUtility
{
    /// <summary>
    /// Extensions to easily read and write Vectors from binary files
    /// </summary>
    static public class BinaryIOExtensions
    {
        static public void Write(this BinaryWriter bw, Vector vec)
        {
            bw.Write(vec.X);
            bw.Write(vec.Y);
            bw.Write(vec.Z);
        }

        static public Vector ReadVector(this BinaryReader br)
        {
            double x = br.ReadDouble();
            double y = br.ReadDouble();
            double z = br.ReadDouble();
            return new Vector(x, y, z);
        }

        static public void Write(this BinaryWriter bw, Vector2D vec)
        {
            bw.Write(vec.X);
            bw.Write(vec.Y);
        }

        static public Vector2D ReadVector2D(this BinaryReader br)
        {
            double x = br.ReadDouble();
            double y = br.ReadDouble();
            return new Vector2D(x, y);
        }

        static public void Write(this BinaryWriter bw, Color color)
        {
            bw.Write(color.R);
            bw.Write(color.G);
            bw.Write(color.B);
            bw.Write(color.A);
        }

        static public Color ReadColor(this BinaryReader br)
        {
            byte r = br.ReadByte();
            byte g = br.ReadByte();
            byte b = br.ReadByte();
            byte a = br.ReadByte();

            return Color.FromArgb(a, r, g, b);
        }

        /// <summary>
        /// Reads a string that was written in C++, with a full int used for size before the character string
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        static public string ReadStringCPP(this BinaryReader br)
        {
            int size = br.ReadInt32();
            var str = br.ReadChars(size);
            return new string(str);
        }
    }
}
