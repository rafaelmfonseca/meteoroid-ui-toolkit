using Meteoroid.Graphics.DataStructures;
using Meteoroid.Graphics.Metadata;
using Meteoroid.Graphics.Utilities;
using UnityEngine;

namespace Meteoroid.Graphics.Controls
{
    public class Box : Widget
    {
        private readonly RectTransform _rectTransform;

        private State<PivotPresets> _pivot;
        public State<PivotPresets> Pivot
        {
            get => _pivot;
            set => RegistryPropertyState(nameof(Pivot), ref _pivot, value);
        }

        private State<AnchorPresets> _anchor;
        public State<AnchorPresets> Anchor
        {
            get => _anchor;
            set => RegistryPropertyState(nameof(Anchor), ref _anchor, value);
        }

        private State<Vector2> _size;
        public State<Vector2> Size
        {
            get => _size;
            set => RegistryPropertyState(nameof(Size), ref _size, value);
        }

        private State<Vector2> _position;
        public State<Vector2> Position
        {
            get => _position;
            set => RegistryPropertyState(nameof(Position), ref _position, value);
        }

        private State<Padding> _padding;
        public State<Padding> Padding
        {
            get => _padding;
            set => RegistryPropertyState(nameof(Padding), ref _padding, value);
        }

        public Box() : base()
        {
            _rectTransform = Element.AddComponent<RectTransform>();
        }

        public override void OnStateChanged(StateChangedEvent e)
        {
            _rectTransform.localScale = Vector3.one;

            if (_pivot is not null)
            {
                _rectTransform.SetPivot(_pivot);
            }

            if (_anchor is not null)
            {
                _rectTransform.SetAnchor(_anchor);
            }

            if (_position is not null)
            {
                _rectTransform.anchoredPosition = new Vector2(_position.Value.x, _position.Value.y);
            }

            if (_padding is not null)
            {
                _rectTransform.SetPadding(_padding);
            }

            if (_size is not null)
            {
                _rectTransform.sizeDelta = _size;
            }
        }

        public override void OnParentChanged(ElementParentChangedEvent e)
        {

        }
    }
}
