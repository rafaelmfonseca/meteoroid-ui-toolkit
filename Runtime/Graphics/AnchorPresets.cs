namespace Meteoroid.Graphics
{
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
