using System;
using System.Collections.Generic;
using Meteoroid.Graphics.Metadata;
using Meteoroid.Graphics.Metadata.Generic;
using UnityEngine.Events;

namespace Meteoroid.Graphics
{
    public class State<T> : IState<T>
    {
        private UnityEvent<ValueChangedEvent<T>> _invokableGenericCallList = new UnityEvent<ValueChangedEvent<T>>();
        private UnityEvent<ValueChangedEvent> _invokableCallList = new UnityEvent<ValueChangedEvent>();
        private bool _disabled;
        private T _value;

        object IState.Value
        {
            get => _value;

            set
            {
                if (Disabled)
                    throw new InvalidOperationException($"Can't set value to \"{value.ToString()}\", the state is disabled.");

                if (EqualityComparer<object>.Default.Equals(_value, value)) return;

                var previousValue = _value;

                _value = (T) value;

                TriggerValueChange(previousValue, _value);
            }
        }

        public T Value
        {
            get => _value;

            set
            {
                if (Disabled)
                    throw new InvalidOperationException($"Can't set value to \"{value.ToString()}\", the state is disabled.");

                if (EqualityComparer<T>.Default.Equals(_value, value)) return;

                var previousValue = _value;

                _value = value;

                TriggerValueChange(previousValue, _value);
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


        public State(T initialValue, bool disabled)
        {
            _disabled = disabled;
            _value = initialValue;
        }

        public State(T initialValue) : this(initialValue, false) { }

        public State() { }

        public void AddListener(UnityAction<ValueChangedEvent<T>> call)
        {
            lock (_invokableGenericCallList)
            {
                _invokableGenericCallList.AddListener(call);
            }
        }

        void IState.AddListener(UnityAction<ValueChangedEvent> call)
        {
            lock (_invokableCallList)
            {
                _invokableCallList.AddListener(call);
            }
        }

        public void RemoveListener(UnityAction<ValueChangedEvent<T>> call)
        {
            lock (_invokableGenericCallList)
            {
                _invokableGenericCallList.RemoveListener(call);
            }
        }

        void IState.RemoveListener(UnityAction<ValueChangedEvent> call)
        {
            lock (_invokableCallList)
            {
                _invokableCallList.RemoveListener(call);
            }
        }

        public void RemoveAllListeners()
        {
            lock (_invokableGenericCallList)
            {
                _invokableGenericCallList.RemoveAllListeners();
            }

            lock (_invokableCallList)
            {
                _invokableCallList.RemoveAllListeners();
            }
        }

        private void TriggerValueChange(T oldValue, T newValue)
        {
            lock (_invokableGenericCallList)
            {
                var args = new ValueChangedEvent<T>(this, oldValue, newValue);

                _invokableGenericCallList.Invoke(args);
            }

            lock (_invokableCallList)
            {
                var args = new ValueChangedEvent(this, oldValue, newValue);

                _invokableCallList.Invoke(args);
            }
        }

        public static implicit operator T(State<T> state) => state.Value;
        public static implicit operator State<T>(T value) => new State<T>(value, true);
    }
}
