using Meteoroid.Graphics.DataStructures;
using Meteoroid.Graphics.Metadata;
using UnityEngine;
using UnityEngine.UI;

namespace Meteoroid.Graphics.Controls
{
    public class Drawable : Box
    {
        private readonly Image _image;

        private State<Sprite> _sprite;
        public State<Sprite> Sprite
        {
            get => _sprite;
            set => RegistryPropertyState(nameof(Sprite), ref _sprite, value);
        }

        private State<Color> _color;
        public State<Color> Color
        {
            get => _color;
            set => RegistryPropertyState(nameof(Color), ref _color, value);
        }

        private State<Material> _material;
        public State<Material> Material
        {
            get => _material;
            set => RegistryPropertyState(nameof(Material), ref _material, value);
        }

        private State<bool> _raycastTarget;
        public State<bool> RaycastTarget
        {
            get => _raycastTarget;
            set => RegistryPropertyState(nameof(RaycastTarget), ref _raycastTarget, value);
        }

        private State<Padding> _raycastPadding;
        public State<Padding> RaycastPadding
        {
            get => _raycastPadding;
            set => RegistryPropertyState(nameof(RaycastPadding), ref _raycastPadding, value);
        }

        private State<bool> _maskable;
        public State<bool> Maskable
        {
            get => _maskable;
            set => RegistryPropertyState(nameof(Maskable), ref _maskable, value);
        }

        private State<Image.Type> _type;
        public State<Image.Type> Type
        {
            get => _type;
            set => RegistryPropertyState(nameof(Type), ref _type, value);
        }

        private State<Image.FillMethod> _fillMethod;
        public State<Image.FillMethod> FillMethod
        {
            get => _fillMethod;
            set => RegistryPropertyState(nameof(FillMethod), ref _fillMethod, value);
        }

        private State<int> _fillOrigin;
        public State<int> FillOrigin
        {
            get => FillOrigin;
            set => RegistryPropertyState(nameof(FillOrigin), ref _fillOrigin, value);
        }

        private State<float> _fillAmount;
        public State<float> FillAmount
        {
            get => FillAmount;
            set => RegistryPropertyState(nameof(FillAmount), ref _fillAmount, value);
        }

        public Drawable() : base()
        {
            _image = Element.AddComponent<Image>();
        }

        public override void OnStateChanged(StateChangedEvent e)
        {
            base.OnStateChanged(e);

            switch(e.PropertyName)
            {
                case nameof(Sprite): _image.sprite = _sprite; break;
                case nameof(Color): _image.color = _color; break;
                case nameof(Material): _image.material = _material; break;
                case nameof(RaycastTarget): _image.raycastTarget = _raycastTarget; break;
                case nameof(RaycastPadding): _image.raycastPadding = (Padding) _raycastPadding; break;
                case nameof(Maskable): _image.maskable = _maskable; break;
                case nameof(Type): _image.type = _type; break;
                case nameof(FillMethod): _image.fillMethod = _fillMethod; break;
                case nameof(FillOrigin): _image.fillOrigin = _fillOrigin; break;
                case nameof(FillAmount): _image.fillAmount = _fillAmount; break;
            };
        }
    }
}
