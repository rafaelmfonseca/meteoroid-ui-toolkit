using System;
using System.Linq;
using UnityEngine;
using Meteoroid.Graphics.Metadata;
using Meteoroid.Graphics.Infrastructure;
using System.Collections.Concurrent;

namespace Meteoroid.Graphics
{
    public abstract class Widget : IWidget, IDisposable
    {
        private readonly IElementParentSetter _parentSetter = new DefaultElementParentSetter();
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
            Element = new GameObject()
            {
                name = $"__ [Widget] {this.GetType().Name}"
            };
        }

        public void RegistryPropertyState<T>(string propertyName, ref State<T> oldState, State<T> newState)
        {
            if (ReferenceEquals(oldState, newState)) return;

            oldState = newState;

            TriggerStateChanged(propertyName);

            if (newState is not null && newState is not { Disabled: true } && newState is IState state)
            {
                state.AddListener(InternalOnValueChanged);
            }

            _states.AddOrUpdate(propertyName, newState, (propertyName, existingState) =>
            {
                if (existingState is not null)
                {
                    existingState.RemoveListener(InternalOnValueChanged);
                }

                return newState;
            });
        }

        public abstract void OnStateChanged(StateChangedEvent e);

        public abstract void OnParentChanged(ElementParentChangedEvent e);

        public virtual void Dispose()
        {
            _states.Clear();

            _element = null;
            _states = null;
        }

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
            if (_children is null)
                return;

            if (_element is null)
                throw new InvalidOperationException($"Tried to set children Transform, but Element is null.");

            for (int i = 0; i < _children.Length; i++)
            {
                if (!ReferenceEquals(_children[i].Element.transform.parent, _element.transform))
                {
                    _parentSetter.Update(_element, _children[i].Element);

                    _children[i].OnParentChanged(new ElementParentChangedEvent(this));
                }
            }
        }
    }
}