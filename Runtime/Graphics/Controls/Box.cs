using Meteoroid.Graphics.Metadata;
using Meteoroid.Graphics.Metadata.Generic;
using UnityEngine;

namespace Meteoroid.Graphics.Controls
{
    public class Box : Widget
    {
        private readonly RectTransform _rectTransform;
        private State<AnchorRect> _anchor;
        private State<Vector2> _pivot;

        public State<AnchorRect> Anchor
        {
            get => _anchor;

            set
            {
                if (_anchor == value) return;

                _anchor = value;

                RegistryPropertyState(nameof(Anchor), value);
            }
        }

        public State<Vector2> Pivot
        {
            get => _pivot;

            set
            {
                if (_pivot == value) return;

                _pivot = value;

                RegistryPropertyState(nameof(Pivot), value);
            }
        }

        public Box() : base()
        {
            _rectTransform = Element.AddComponent<RectTransform>();
        }

        public override void OnStateChanged(StateChangedEvent e)
        {
            if (e.PropertyName == nameof(Anchor))
            {
                _rectTransform.anchorMax = _anchor.Value.anchorMax;
                _rectTransform.anchorMin = _anchor.Value.anchorMin;

                _rectTransform.ForceUpdateRectTransforms();
            }
            else if (e.PropertyName == nameof(Pivot))
            {
                _rectTransform.pivot = _pivot.Value;

                _rectTransform.ForceUpdateRectTransforms();
            }
        }
    }
}
