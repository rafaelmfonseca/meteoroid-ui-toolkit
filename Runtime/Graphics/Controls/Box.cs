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

        public Box() : base()
        {
            _rectTransform = Element.AddComponent<RectTransform>();
        }

        public override void OnStateChanged(StateChangedEvent e)
        {
            if (   (_pivot    is not null)
                && (_anchor   is not null)
                && (_size     is not null)
                && (_position is not null))
            {
                _rectTransform.localScale = Vector3.one;

                _rectTransform.SetPivot(_pivot);
                _rectTransform.SetAnchor(_anchor);

                var anchoredPosition = new Vector2(_position.Value.x, _position.Value.y);

                _rectTransform.anchoredPosition = anchoredPosition;
                _rectTransform.sizeDelta = _size;
            }
        }

        public override void OnParentChanged(ElementParentChangedEvent e)
        {

        }
    }
}
