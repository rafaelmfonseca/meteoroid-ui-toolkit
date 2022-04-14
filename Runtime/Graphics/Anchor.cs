using UnityEngine;

namespace Meteoroid.Graphics
{
    public struct AnchorRect
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
    }

    public static class AnchorPresets
    {
        public static readonly AnchorRect TopLeft = new AnchorRect(minX: 0.0f, minY: 1.0f, maxX: 0.0f, maxY: 1.0f);
        public static readonly AnchorRect TopCenter = new AnchorRect(minX: 0.5f, minY: 1.0f, maxX: 0.5f, maxY: 1.0f);
        public static readonly AnchorRect TopRight = new AnchorRect(minX: 1.0f, minY: 1.0f, maxX: 1.0f, maxY: 1.0f);
        public static readonly AnchorRect TopStretch = new AnchorRect(minX: 0.0f, minY: 1.0f, maxX: 1.0f, maxY: 1.0f);

        public static readonly AnchorRect MiddleLeft = new AnchorRect(minX: 0.0f, minY: 0.5f, maxX: 0.0f, maxY: 0.5f);
        public static readonly AnchorRect MiddleCenter = new AnchorRect(minX: 0.5f, minY: 0.5f, maxX: 0.5f, maxY: 0.5f);
        public static readonly AnchorRect MiddleRight = new AnchorRect(minX: 1.0f, minY: 0.5f, maxX: 1.0f, maxY: 0.5f);
        public static readonly AnchorRect MiddleStretch = new AnchorRect(minX: 0.0f, minY: 0.5f, maxX: 1.0f, maxY: 0.5f);

        public static readonly AnchorRect BottomLeft = new AnchorRect(minX: 0.0f, minY: 0.0f, maxX: 0.0f, maxY: 0.0f);
        public static readonly AnchorRect BottomCenter = new AnchorRect(minX: 0.5f, minY: 0.0f, maxX: 0.5f, maxY: 0.0f);
        public static readonly AnchorRect BottomRight = new AnchorRect(minX: 1.0f, minY: 0.0f, maxX: 1.0f, maxY: 0.0f);
        public static readonly AnchorRect BottomStretch = new AnchorRect(minX: 0.0f, minY: 0.0f, maxX: 1.0f, maxY: 0.0f);

        public static readonly AnchorRect StretchLeft = new AnchorRect(minX: 0.0f, minY: 0.0f, maxX: 0.0f, maxY: 1.0f);
        public static readonly AnchorRect StretchCenter = new AnchorRect(minX: 0.5f, minY: 0.0f, maxX: 0.5f, maxY: 1.0f);
        public static readonly AnchorRect StretchRight = new AnchorRect(minX: 1.0f, minY: 0.0f, maxX: 1.0f, maxY: 1.0f);
        public static readonly AnchorRect StretchStretch = new AnchorRect(minX: 0.0f, minY: 0.0f, maxX: 1.0f, maxY: 1.0f);
    }
}
