using UnityEngine;
using Meteoroid.Graphics.DataStructures;

namespace Meteoroid.Graphics.Utilities
{
    internal static class RectTransformExtensions
    {
        public static void SetAnchor(this RectTransform source, AnchorPresets anchor, float offsetX = 0f, float offsetY = 0f)
        {
            source.anchoredPosition = new Vector3(offsetX, offsetY, 0f);

            switch (anchor)
            {
                case AnchorPresets.TopLeft:
                    source.anchorMin = new Vector2(0.0f, 1.0f);
                    source.anchorMax = new Vector2(0.0f, 1.0f);
                    break;
                case AnchorPresets.TopCenter:
                    source.anchorMin = new Vector2(0.5f, 1.0f);
                    source.anchorMax = new Vector2(0.5f, 1.0f);
                    break;
                case AnchorPresets.TopRight:
                    source.anchorMin = new Vector2(1.0f, 1.0f);
                    source.anchorMax = new Vector2(1.0f, 1.0f);
                    break;
                case AnchorPresets.TopStretch:
                    source.anchorMin = new Vector2(0.0f, 1.0f);
                    source.anchorMax = new Vector2(1.0f, 1.0f);
                    break;
                case AnchorPresets.MiddleLeft:
                    source.anchorMin = new Vector2(0.0f, 0.5f);
                    source.anchorMax = new Vector2(0.0f, 0.5f);
                    break;
                case AnchorPresets.MiddleCenter:
                    source.anchorMin = new Vector2(0.5f, 0.5f);
                    source.anchorMax = new Vector2(0.5f, 0.5f);
                    break;
                case AnchorPresets.MiddleRight:
                    source.anchorMin = new Vector2(1.0f, 0.5f);
                    source.anchorMax = new Vector2(1.0f, 0.5f);
                    break;
                case AnchorPresets.MiddleStretch:
                    source.anchorMin = new Vector2(0.0f, 0.5f);
                    source.anchorMax = new Vector2(1.0f, 0.5f);
                    break;
                case AnchorPresets.BottomLeft:
                    source.anchorMin = new Vector2(0.0f, 0.0f);
                    source.anchorMax = new Vector2(0.0f, 0.0f);
                    break;
                case AnchorPresets.BottomCenter:
                    source.anchorMin = new Vector2(0.5f, 0.0f);
                    source.anchorMax = new Vector2(0.5f, 0.0f);
                    break;
                case AnchorPresets.BottomRight:
                    source.anchorMin = new Vector2(1.0f, 0.0f);
                    source.anchorMax = new Vector2(1.0f, 0.0f);
                    break;
                case AnchorPresets.BottomStretch:
                    source.anchorMin = new Vector2(0.0f, 0.0f);
                    source.anchorMax = new Vector2(1.0f, 0.0f);
                    break;
                case AnchorPresets.StretchLeft:
                    source.anchorMin = new Vector2(0.0f, 0.0f);
                    source.anchorMax = new Vector2(0.0f, 1.0f);
                    break;
                case AnchorPresets.StretchCenter:
                    source.anchorMin = new Vector2(0.5f, 0.0f);
                    source.anchorMax = new Vector2(0.5f, 1.0f);
                    break;
                case AnchorPresets.StretchRight:
                    source.anchorMin = new Vector2(1.0f, 0.0f);
                    source.anchorMax = new Vector2(1.0f, 1.0f);
                    break;
                case AnchorPresets.StretchAll:
                    source.anchorMin = new Vector2(0.0f, 0.0f);
                    source.anchorMax = new Vector2(1.0f, 1.0f);
                    break;
            }
        }

        public static void SetPivot(this RectTransform source, PivotPresets pivot)
        {
            switch(pivot)
            {
                case PivotPresets.TopLeft:
                    source.pivot = new Vector2(0.0f, 1.0f);
                    break;
                case PivotPresets.TopCenter:
                    source.pivot = new Vector2(0.5f, 1.0f);
                    break;
                case PivotPresets.TopRight:
                    source.pivot = new Vector2(1.0f, 1.0f);
                    break;
                case PivotPresets.TopStretch:
                    source.pivot = new Vector2(0.5f, 1.0f);
                    break;
                case PivotPresets.MiddleLeft:
                    source.pivot = new Vector2(0.0f, 0.5f);
                    break;
                case PivotPresets.MiddleCenter:
                    source.pivot = new Vector2(0.5f, 0.5f);
                    break;
                case PivotPresets.MiddleRight:
                    source.pivot = new Vector2(1.0f, 0.5f);
                    break;
                case PivotPresets.MiddleStretch:
                    source.pivot = new Vector2(0.5f, 0.5f);
                    break;
                case PivotPresets.BottomLeft:
                    source.pivot = new Vector2(0.0f, 0.0f);
                    break;
                case PivotPresets.BottomCenter:
                    source.pivot = new Vector2(0.5f, 0.0f);
                    break;
                case PivotPresets.BottomRight:
                    source.pivot = new Vector2(1.0f, 0.0f);
                    break;
                case PivotPresets.BottomStretch:
                    source.pivot = new Vector2(0.5f, 0.0f);
                    break;
                case PivotPresets.StretchLeft:
                    source.pivot = new Vector2(0.0f, 0.5f);
                    break;
                case PivotPresets.StretchCenter:
                    source.pivot = new Vector2(0.5f, 0.5f);
                    break;
                case PivotPresets.StretchRight:
                    source.pivot = new Vector2(1.0f, 0.5f);
                    break;
                case PivotPresets.StretchAll:
                    source.pivot = new Vector2(0.5f, 0.5f);
                    break;
            }
        }
    }
}
