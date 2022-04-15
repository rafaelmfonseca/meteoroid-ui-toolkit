using Meteoroid.Graphics.Metadata;
using UnityEngine;

namespace Meteoroid.Graphics.Controls
{
    public class Box : Widget
    {
        private readonly RectTransform _rectTransform;
        private State<AnchorRect> _anchor;

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
        }
    }
}
