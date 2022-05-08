using UnityEngine;
using Meteoroid.Graphics.DataStructures;

namespace Meteoroid.Graphics.Utilities
{
    internal static class RectTransformExtensions
    {
        public static void SetAnchor(this RectTransform rectTransform, AnchorPresets anchor, float offsetX = 0f, float offsetY = 0f)
        {
            switch (anchor)
            {
                case AnchorPresets.TopLeft:
                    rectTransform.anchorMin = new Vector2(0.0f, 1.0f);
                    rectTransform.anchorMax = new Vector2(0.0f, 1.0f);
                    break;
                case AnchorPresets.TopCenter:
                    rectTransform.anchorMin = new Vector2(0.5f, 1.0f);
                    rectTransform.anchorMax = new Vector2(0.5f, 1.0f);
                    break;
                case AnchorPresets.TopRight:
                    rectTransform.anchorMin = new Vector2(1.0f, 1.0f);
                    rectTransform.anchorMax = new Vector2(1.0f, 1.0f);
                    break;
                case AnchorPresets.TopStretch:
                    rectTransform.anchorMin = new Vector2(0.0f, 1.0f);
                    rectTransform.anchorMax = new Vector2(1.0f, 1.0f);
                    break;
                case AnchorPresets.MiddleLeft:
                    rectTransform.anchorMin = new Vector2(0.0f, 0.5f);
                    rectTransform.anchorMax = new Vector2(0.0f, 0.5f);
                    break;
                case AnchorPresets.MiddleCenter:
                    rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
                    rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
                    break;
                case AnchorPresets.MiddleRight:
                    rectTransform.anchorMin = new Vector2(1.0f, 0.5f);
                    rectTransform.anchorMax = new Vector2(1.0f, 0.5f);
                    break;
                case AnchorPresets.MiddleStretch:
                    rectTransform.anchorMin = new Vector2(0.0f, 0.5f);
                    rectTransform.anchorMax = new Vector2(1.0f, 0.5f);
                    break;
                case AnchorPresets.BottomLeft:
                    rectTransform.anchorMin = new Vector2(0.0f, 0.0f);
                    rectTransform.anchorMax = new Vector2(0.0f, 0.0f);
                    break;
                case AnchorPresets.BottomCenter:
                    rectTransform.anchorMin = new Vector2(0.5f, 0.0f);
                    rectTransform.anchorMax = new Vector2(0.5f, 0.0f);
                    break;
                case AnchorPresets.BottomRight:
                    rectTransform.anchorMin = new Vector2(1.0f, 0.0f);
                    rectTransform.anchorMax = new Vector2(1.0f, 0.0f);
                    break;
                case AnchorPresets.BottomStretch:
                    rectTransform.anchorMin = new Vector2(0.0f, 0.0f);
                    rectTransform.anchorMax = new Vector2(1.0f, 0.0f);
                    break;
                case AnchorPresets.StretchLeft:
                    rectTransform.anchorMin = new Vector2(0.0f, 0.0f);
                    rectTransform.anchorMax = new Vector2(0.0f, 1.0f);
                    break;
                case AnchorPresets.StretchCenter:
                    rectTransform.anchorMin = new Vector2(0.5f, 0.0f);
                    rectTransform.anchorMax = new Vector2(0.5f, 1.0f);
                    break;
                case AnchorPresets.StretchRight:
                    rectTransform.anchorMin = new Vector2(1.0f, 0.0f);
                    rectTransform.anchorMax = new Vector2(1.0f, 1.0f);
                    break;
                case AnchorPresets.StretchAll:
                    rectTransform.anchorMin = new Vector2(0.0f, 0.0f);
                    rectTransform.anchorMax = new Vector2(1.0f, 1.0f);
                    break;
            }
        }

        public static void SetPivot(this RectTransform rectTransform, PivotPresets pivot)
        {
            switch (pivot)
            {
                case PivotPresets.TopLeft:
                    rectTransform.pivot = new Vector2(0.0f, 1.0f);
                    break;
                case PivotPresets.TopCenter:
                    rectTransform.pivot = new Vector2(0.5f, 1.0f);
                    break;
                case PivotPresets.TopRight:
                    rectTransform.pivot = new Vector2(1.0f, 1.0f);
                    break;
                case PivotPresets.TopStretch:
                    rectTransform.pivot = new Vector2(0.5f, 1.0f);
                    break;
                case PivotPresets.MiddleLeft:
                    rectTransform.pivot = new Vector2(0.0f, 0.5f);
                    break;
                case PivotPresets.MiddleCenter:
                    rectTransform.pivot = new Vector2(0.5f, 0.5f);
                    break;
                case PivotPresets.MiddleRight:
                    rectTransform.pivot = new Vector2(1.0f, 0.5f);
                    break;
                case PivotPresets.MiddleStretch:
                    rectTransform.pivot = new Vector2(0.5f, 0.5f);
                    break;
                case PivotPresets.BottomLeft:
                    rectTransform.pivot = new Vector2(0.0f, 0.0f);
                    break;
                case PivotPresets.BottomCenter:
                    rectTransform.pivot = new Vector2(0.5f, 0.0f);
                    break;
                case PivotPresets.BottomRight:
                    rectTransform.pivot = new Vector2(1.0f, 0.0f);
                    break;
                case PivotPresets.BottomStretch:
                    rectTransform.pivot = new Vector2(0.5f, 0.0f);
                    break;
                case PivotPresets.StretchLeft:
                    rectTransform.pivot = new Vector2(0.0f, 0.5f);
                    break;
                case PivotPresets.StretchCenter:
                    rectTransform.pivot = new Vector2(0.5f, 0.5f);
                    break;
                case PivotPresets.StretchRight:
                    rectTransform.pivot = new Vector2(1.0f, 0.5f);
                    break;
                case PivotPresets.StretchAll:
                    rectTransform.pivot = new Vector2(0.5f, 0.5f);
                    break;
            }
        }
    }
}
