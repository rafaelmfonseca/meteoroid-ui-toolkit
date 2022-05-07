using System;

namespace Meteoroid.Graphics.DataStructures
{
    [Serializable]
    public enum AnchorPresets
    {
        TopLeft,
        TopCenter,
        TopRight,
        TopStretch,

        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        MiddleStretch,

        BottomLeft,
        BottomCenter,
        BottomRight,
        BottomStretch,

        StretchLeft,
        StretchCenter,
        StretchRight,
        StretchAll,
    }
}
