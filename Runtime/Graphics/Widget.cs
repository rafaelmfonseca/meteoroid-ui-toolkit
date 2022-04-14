using System;
using UnityEngine;
using Meteoroid.Graphics.Metadata;

namespace Meteoroid.Graphics
{
    public abstract class Widget : IWidget
    {
        private IWidget[] _children;
        private GameObject _element;

        public IWidget[] Children
        {
            get => _children;

            set
            {
                if (_children == value)
                    return;

                _children = value;

                UpdateChildrenParent();
            }
        }

        public GameObject Element
        {
            get => _element;

            set
            {
                if (_element == value)
                    return;

                _element = value;

                UpdateChildrenParent();
            }
        }

        public abstract void OnPropertyChanged(PropertyChangedEvent e);

        public void NotifyPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEvent(propertyName));
        }

        private void UpdateChildrenParent()
        {
            if (_children == null)
                return;

            if (_element == null)
                throw new InvalidOperationException($"Tried to set children Transform, but Element is null.");

            for (int i = 0; i < _children.Length; i++)
            {
                _children[i].Element.transform.SetParent(_element.transform);
            }
        }
    }
}