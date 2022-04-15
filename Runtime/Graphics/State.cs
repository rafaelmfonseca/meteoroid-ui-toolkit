using System;
using System.Collections.Generic;
using Meteoroid.Graphics.Metadata;
using UnityEngine.Events;

namespace Meteoroid.Graphics
{
    public class State : IState
    {
        private UnityEvent<ValueChangedEvent> _invokableCallList = new UnityEvent<ValueChangedEvent>();
        private bool _disabled;
        private object _value;

        public object Value
        {
            get => _value;

            set
            {
                if (Disabled)
                    throw new InvalidOperationException($"Can't set value to \"{value.ToString()}\", the state is disabled.");

                if (EqualityComparer<object>.Default.Equals(_value, value)) return;

                var previousValue = _value;

                _value = value;

                var args = new ValueChangedEvent(this, previousValue, _value);

                _invokableCallList?.Invoke(args);
            }
        }

        public bool Disabled
        {
            get => _disabled;

            set
            {
                if (_disabled == value) return;

                _disabled = value;
            }
        }

        public State(object value)
        {
            Value = value;
        }

        public State() { }

        public void AddListener(UnityAction<ValueChangedEvent> call)
        {
            lock (_invokableCallList)
            {
                _invokableCallList.AddListener(call);
            }
        }

        public void RemoveListener(UnityAction<ValueChangedEvent> call)
        {
            lock (_invokableCallList)
            {
                _invokableCallList.RemoveListener(call);
            }
        }

        public void RemoveAllListeners()
        {
            lock (_invokableCallList)
            {
                _invokableCallList.RemoveAllListeners();
            }
        }
    }
}
