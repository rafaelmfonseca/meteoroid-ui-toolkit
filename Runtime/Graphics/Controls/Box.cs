using System;
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
                if (_anchor == value)
                    return;

                _anchor = value;

                NotifyPropertyChanged(nameof(Anchor));
            }
        }

        public Box()
        {
            Element = new GameObject();

            _rectTransform = Element.AddComponent<RectTransform>();
        }

        public override void OnPropertyChanged(PropertyChangedEvent e)
        {
            if (e.PropertyName == nameof(Anchor))
            {
                Action anchorChanged = () =>
                {
                    _rectTransform.anchorMax = _anchor.Value.anchorMax;
                    _rectTransform.anchorMin = _anchor.Value.anchorMin;

                    _rectTransform.ForceUpdateRectTransforms();
                };

                anchorChanged();

                Anchor.AddListener(anchorChanged);
            }
        }
    }
}
