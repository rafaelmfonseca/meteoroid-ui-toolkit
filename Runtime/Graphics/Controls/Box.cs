using Meteoroid.Graphics.DataStructures;
using Meteoroid.Graphics.Metadata;
using Meteoroid.Graphics.Utilities;
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
            set => RegistryPropertyState(nameof(RectTransformData), ref _rectTransformData, value);
        }

        public Box() : base()
        {
            _rectTransform = Element.AddComponent<RectTransform>();
        }

        public override void OnStateChanged(StateChangedEvent e)
        {
            if (e.PropertyName == nameof(RectTransformData))
            {
                if (_rectTransformData is not null)
                {
                    _rectTransform.SetAnchor(_rectTransformData.Value.anchor);
                    _rectTransform.SetPivot(_rectTransformData.Value.pivot);
                }
            }
        }

        public override void OnParentChanged(ElementParentChangedEvent e)
        {

        }
    }
}
