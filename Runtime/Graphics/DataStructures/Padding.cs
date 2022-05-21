using System;
using System.Globalization;
using UnityEngine;

namespace Meteoroid.Graphics.DataStructures
{
    public struct Padding : IEquatable<Padding>, IFormattable
    {
        private static readonly Padding zeroPadding = new Padding(0f);

        public static Padding zero => zeroPadding;

        public float left;
        public float top;

        public float right;
        public float bottom;

        public Padding(float allSides)
        {
            left = top = right = bottom = allSides;
        }

        public Padding(float left, float top, float right, float bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        public override bool Equals(object other)
        {
            if (!(other is Padding)) return false;

            return Equals((Padding) other);
        }

        public bool Equals(Padding other)
        {
            return left == other.left && top == other.top && right == other.right && bottom == other.bottom;
        }

        public override int GetHashCode()
        {
            return top.GetHashCode() ^ (right.GetHashCode() << 4) ^ (bottom.GetHashCode() >> 28) ^ (left.GetHashCode() >> 4);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (formatProvider == null)
                formatProvider = CultureInfo.InvariantCulture.NumberFormat;

            return String.Format("(left: {0}, top {0}, right: {0}, bottom: {0})",
                left.ToString(format, formatProvider),
                top.ToString(format, formatProvider),
                right.ToString(format, formatProvider),
                bottom.ToString(format, formatProvider));
        }

        /// <summary>
        /// X = Left
        /// Y = Bottom
        /// Z = Right
        /// W = Top
        /// </summary>
        public static implicit operator Vector4(Padding padding)
            => new Vector4(padding.left, padding.bottom, padding.right, padding.top);
    }
}
