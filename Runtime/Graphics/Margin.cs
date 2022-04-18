using System;
using System.Globalization;

namespace Meteoroid.Graphics
{
    public struct Margin : IEquatable<Margin>, IFormattable
    {
        public float left;
        public float right;

        public float top;
        public float bottom;

        public Margin(float left, float right, float top, float bottom)
        {
            this.left = left;
            this.right = right;
            this.top = top;
            this.bottom = bottom;
        }

        public override bool Equals(object other)
        {
            if (!(other is Margin)) return false;

            return Equals((Margin)other);
        }

        public bool Equals(Margin other)
        {
            return left == other.left && right == other.right && top == other.top && bottom == other.bottom;
        }

        public override int GetHashCode()
        {
            return left.GetHashCode() ^ (right.GetHashCode() << 4) ^ (top.GetHashCode() >> 28) ^ (bottom.GetHashCode() >> 4);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (formatProvider == null)
                formatProvider = CultureInfo.InvariantCulture.NumberFormat;

            return String.Format("({0}, {1}, {2}, {3})",
                left.ToString(format, formatProvider),
                right.ToString(format, formatProvider),
                top.ToString(format, formatProvider),
                bottom.ToString(format, formatProvider));
        }
    }
}
