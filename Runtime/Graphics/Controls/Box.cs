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
            /**
             * m_AnchoredPosition: {x: ((left - right) / 2) + x, y: ((bottom - top) / 2) + y}
             * m_SizeDelta: {x: -(left + right) + width, y: -(top + bottom) + height}
             */
            _rectTransform.localScale = Vector3.one;

            _rectTransform.SetPivot(_pivot ?? PivotPresets.TopLeft);
            _rectTransform.SetAnchor(_anchor ?? AnchorPresets.TopLeft);

            ForceUpdateAnchoredPosition();

            ForceUpdateSizeDelta();

            _rectTransform.ForceUpdateRectTransforms();
        }

        private void ForceUpdateAnchoredPosition()
        {
            Vector2 anchoredPosition = Vector2.zero;

            if (_padding is not null)
            {
                var padding = _padding.Value;

                anchoredPosition += new Vector2((padding.left - padding.right) / 2, (padding.bottom - padding.top) / 2);
            }

            if (_position is not null)
            {
                anchoredPosition += _position;
            }

            _rectTransform.anchoredPosition = anchoredPosition;
        }

        private void ForceUpdateSizeDelta()
        {
            Vector2 sizeDelta = Vector2.zero;

            if (_padding is not null)
            {
                var padding = _padding.Value;

                sizeDelta += new Vector2(-(padding.left + padding.right), -(padding.top + padding.bottom));
            }

            if (_size is not null)
            {
                sizeDelta += _size;
            }

            _rectTransform.sizeDelta = sizeDelta;
        }

        public override void OnParentChanged(ElementParentChangedEvent e)
        {

        }
    }
}
