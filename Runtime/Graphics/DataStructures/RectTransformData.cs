using System;
using System.Runtime.InteropServices;

namespace Meteoroid.Graphics.DataStructures
{
    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct RectTransformData
    {
        public AnchorPresets anchor;

        public PivotPresets pivot;

        public RectTransformData(AnchorPresets anchor, PivotPresets pivot)
        {
            this.anchor = anchor;
            this.pivot = pivot;
        }
    }
}
