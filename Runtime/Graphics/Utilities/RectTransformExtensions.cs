using UnityEngine;
using Meteoroid.Graphics.DataStructures;

namespace Meteoroid.Graphics.Utilities
{
    internal static class RectTransformExtensions
    {
        public static void SetAnchor(this RectTransform rectTransform, AnchorPresets anchor, float offsetX = 0f, float offsetY = 0f)
        {
            Vector2 size = rectTransform.rect.size;

            rectTransform.anchoredPosition = new Vector3(offsetX, offsetY, 0f);

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

            rectTransform.sizeDelta = size;
        }

        public static void SetPivot(this RectTransform rectTransform, PivotPresets pivot)
        {
            Vector2 newPivot = Vector2.zero;

            switch (pivot)
            {
                case PivotPresets.TopLeft:
                    newPivot = new Vector2(0.0f, 1.0f);
                    break;
                case PivotPresets.TopCenter:
                    newPivot = new Vector2(0.5f, 1.0f);
                    break;
                case PivotPresets.TopRight:
                    newPivot = new Vector2(1.0f, 1.0f);
                    break;
                case PivotPresets.TopStretch:
                    newPivot = new Vector2(0.5f, 1.0f);
                    break;
                case PivotPresets.MiddleLeft:
                    newPivot = new Vector2(0.0f, 0.5f);
                    break;
                case PivotPresets.MiddleCenter:
                    newPivot = new Vector2(0.5f, 0.5f);
                    break;
                case PivotPresets.MiddleRight:
                    newPivot = new Vector2(1.0f, 0.5f);
                    break;
                case PivotPresets.MiddleStretch:
                    newPivot = new Vector2(0.5f, 0.5f);
                    break;
                case PivotPresets.BottomLeft:
                    newPivot = new Vector2(0.0f, 0.0f);
                    break;
                case PivotPresets.BottomCenter:
                    newPivot = new Vector2(0.5f, 0.0f);
                    break;
                case PivotPresets.BottomRight:
                    newPivot = new Vector2(1.0f, 0.0f);
                    break;
                case PivotPresets.BottomStretch:
                    newPivot = new Vector2(0.5f, 0.0f);
                    break;
                case PivotPresets.StretchLeft:
                    newPivot = new Vector2(0.0f, 0.5f);
                    break;
                case PivotPresets.StretchCenter:
                    newPivot = new Vector2(0.5f, 0.5f);
                    break;
                case PivotPresets.StretchRight:
                    newPivot = new Vector2(1.0f, 0.5f);
                    break;
                case PivotPresets.StretchAll:
                    newPivot = new Vector2(0.5f, 0.5f);
                    break;
            }

            Vector2 size = rectTransform.rect.size;
            Vector2 vector = rectTransform.pivot - newPivot;
            Vector3 vector2 = new Vector3(vector.x * size.x, vector.y * size.y);
            rectTransform.pivot = newPivot;
            rectTransform.localPosition -= vector2;
        }
    }
}
