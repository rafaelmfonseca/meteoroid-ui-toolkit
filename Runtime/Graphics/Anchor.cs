using System;
using System.Globalization;
using UnityEngine;

namespace Meteoroid.Graphics
{
    public struct AnchorRect : IEquatable<AnchorRect>, IFormattable
    {
        public float minX;
        public float maxX;

        public float minY;
        public float maxY;

        public Vector2 anchorMax => new Vector2(maxX, maxY);

        public Vector2 anchorMin => new Vector2(minX, minY);

        public AnchorRect(Vector2 anchorMin, Vector2 anchorMax)
        {
            minX = anchorMin.x;
            minY = anchorMin.y;

            maxX = anchorMax.x;
            maxY = anchorMax.y;
        }

        public AnchorRect(float minX, float minY, float maxX, float maxY)
        {
            this.minX = minX;
            this.minY = minY;

            this.maxX = maxX;
            this.maxY = maxY;
        }

        public override bool Equals(object other)
        {
            if (!(other is AnchorRect)) return false;

            return Equals((AnchorRect)other);
        }

        public bool Equals(AnchorRect other)
        {
            return minX == other.minX && minY == other.minY && maxX == other.maxX && maxY == other.maxY;
        }

        public override int GetHashCode()
        {
            return minX.GetHashCode() ^ (minY.GetHashCode() << 4) ^ (maxX.GetHashCode() >> 28) ^ (maxY.GetHashCode() >> 4);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (formatProvider == null)
                formatProvider = CultureInfo.InvariantCulture.NumberFormat;

            return String.Format("(max: [{0}, {1}], min: [{2}, {3}])",
                maxX.ToString(format, formatProvider),
                maxY.ToString(format, formatProvider),
                minX.ToString(format, formatProvider),
                minY.ToString(format, formatProvider));
        }
    }
}
