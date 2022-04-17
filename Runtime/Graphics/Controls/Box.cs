﻿using Meteoroid.Graphics.Metadata;
using UnityEngine;
using Meteoroid.Utilities;

namespace Meteoroid.Graphics.Controls
{
    public class Box : Widget
    {
        private readonly RectTransform _rectTransform;
        private State<AnchorRect> _anchor;
        private State<Vector2> _pivot;
        private State<Vector3> _position;
        private State<Vector2> _size;

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

        public State<Vector3> Position
        {
            get => _position;

            set
            {
                if (_position == value) return;

                _position = value;

                RegistryPropertyState(nameof(Position), value);
            }
        }

        public State<Vector2> Size
        {
            get => _size;

            set
            {
                if (_size == value) return;

                _size = value;

                RegistryPropertyState(nameof(Size), value);
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
                _rectTransform.anchorMin = _anchor.Value.anchorMin;
                _rectTransform.anchorMax = _anchor.Value.anchorMax;
            }
            else if (e.PropertyName == nameof(Pivot))
            {
                var position = _rectTransform.localPosition;

                _rectTransform.pivot = _pivot;

                _rectTransform.localPosition = position;
            }
            else if (e.PropertyName == nameof(Position))
            {
                _rectTransform.anchoredPosition3D = _position;
            }
            else if (e.PropertyName == nameof(Size))
            {
                _rectTransform.sizeDelta = _size;
            }
        }

        public override void OnParentChanged(ElementParentChangedEvent e)
        {

        }
    }
}
