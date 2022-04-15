using System;
using System.Linq;
using UnityEngine;
using Meteoroid.Graphics.Metadata;
using System.Collections.Concurrent;

namespace Meteoroid.Graphics
{
    public abstract class Widget : IWidget
    {
        private ConcurrentDictionary<string, IState> _states = new ConcurrentDictionary<string, IState>();
        private IWidget[] _children;
        private GameObject _element;

        public IWidget[] Children
        {
            get => _children;

            set
            {
                if (_children == value) return;

                _children = value;

                UpdateChildrenParent();
            }
        }

        public GameObject Element
        {
            get => _element;

            set
            {
                if (_element == value) return;

                _element = value;

                UpdateChildrenParent();
            }
        }

        public Widget()
        {
            Element = new GameObject();
        }

        public void RegistryPropertyState(string propertyName, IState newState)
        {
            TriggerStateChanged(propertyName);

            newState.AddListener(InternalOnValueChanged);

            _states.AddOrUpdate(propertyName, newState, (propertyName, existingState) =>
            {
                if (existingState != null)
                {
                    existingState.RemoveListener(InternalOnValueChanged);
                }

                return newState;
            });
        }

        public abstract void OnStateChanged(StateChangedEvent e);

        private void InternalOnValueChanged(ValueChangedEvent args)
        {
            var propertyName = _states.FirstOrDefault((keyPair) => keyPair.Value == args.State).Key;

            TriggerStateChanged(propertyName);
        }

        private void TriggerStateChanged(string propertyName)
        {
            OnStateChanged(new StateChangedEvent(propertyName));
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