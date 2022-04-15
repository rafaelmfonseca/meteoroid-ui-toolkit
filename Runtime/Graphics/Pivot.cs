using UnityEngine;

namespace Meteoroid.Graphics
{
    public static class PivotPresets
    {
        public static readonly Vector2 TopLeft = new Vector2(x: 0.0f, y: 1.0f);
        public static readonly Vector2 TopCenter = new Vector2(x: 0.5f, y: 1.0f);
        public static readonly Vector2 TopRight = new Vector2(x: 1.0f, y: 1.0f);
        public static readonly Vector2 TopStretch = new Vector2(x: 0.5f, y: 1.0f);

        public static readonly Vector2 MiddleLeft = new Vector2(x: 0.0f, y: 0.5f);
        public static readonly Vector2 MiddleCenter = new Vector2(x: 0.5f, y: 0.5f);
        public static readonly Vector2 MiddleRight = new Vector2(x: 1.0f, y: 0.5f);
        public static readonly Vector2 MiddleStretch = new Vector2(x: 0.5f, y: 0.5f);

        public static readonly Vector2 BottomLeft = new Vector2(x: 0.0f, y: 0.0f);
        public static readonly Vector2 BottomCenter = new Vector2(x: 0.5f, y: 0.0f);
        public static readonly Vector2 BottomRight = new Vector2(x: 1.0f, y: 0.0f);
        public static readonly Vector2 BottomStretch = new Vector2(x: 0.5f, y: 0.0f);

        public static readonly Vector2 StretchLeft = new Vector2(x: 0.0f, y: 0.5f);
        public static readonly Vector2 StretchCenter = new Vector2(x: 0.5f, y: 0.5f);
        public static readonly Vector2 StretchRight = new Vector2(x: 1.0f, y: 0.5f);
        public static readonly Vector2 StretchStretch = new Vector2(x: 0.5f, y: 0.5f);
    }
}
