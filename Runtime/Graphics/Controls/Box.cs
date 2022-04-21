using Meteoroid.Graphics.DataStructures;
using Meteoroid.Graphics.Metadata;
using UnityEngine;

namespace Meteoroid.Graphics.Controls
{
    public class Box : Widget
    {
        private readonly RectTransform _rectTransform;
        private State<RectTransformData> _rectTransformData;

        public State<RectTransformData> RectTransformData
        {
            get => _rectTransformData;
            set => RegistryPropertyState(ref _rectTransformData, nameof(RectTransformData), value);
        }

        public Box() : base()
        {
            _rectTransform = Element.AddComponent<RectTransform>();
        }

        public override void OnStateChanged(StateChangedEvent e)
        {
            if (e.PropertyName == nameof(RectTransformData))
            {

            }
        }

        public override void OnParentChanged(ElementParentChangedEvent e)
        {

        }
    }
}
