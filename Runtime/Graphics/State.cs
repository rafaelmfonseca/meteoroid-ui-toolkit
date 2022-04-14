using System;
using System.Collections.Generic;

namespace Meteoroid.Graphics
{
    public class State<T>
    {
        private List<Action<ValueChangedEvent<T>>> _invokableCallList;
        private Func<T> _valueSource;
        private T _value;

        public T Value
        {
            get => _value;

            set
            {
                if (EqualityComparer<T>.Default.Equals(_value, value)) return;

                var previousValue = _value;

                _value = value;

                var parameters = new ValueChangedEvent<T>(previousValue, _value);

                if (_invokableCallList == null)
                    return;

                for (var i = 0; i < _invokableCallList.Count; i++)
                {
                    _invokableCallList[i].Invoke(parameters);
                }
            }
        }

        public State(Func<T> valueSource)
        {
            _valueSource = valueSource;

            TriggerValueSource();
        }

        public State(T initialValue)
        {
            Value = initialValue;
        }

        public State() { }

        public void AddListener(Action<ValueChangedEvent<T>> listener)
        {
            if (_invokableCallList == null)
                _invokableCallList = new List<Action<ValueChangedEvent<T>>>();

            _invokableCallList.Add(listener);
        }

        public void AddListener(Action listener)
        {
            if (_invokableCallList == null)
                _invokableCallList = new List<Action<ValueChangedEvent<T>>>();

            _invokableCallList.Add((e) => listener());
        }

        public void ClearAllListeners()
        {
            if (_invokableCallList == null)
                return;

            _invokableCallList.Clear();
        }

        public void TriggerValueSource()
        {
            if (_valueSource == null)
                throw new InvalidOperationException($"Cannot trigger state without a source.");

            Value = _valueSource();
        }

        public static implicit operator T(State<T> state) => state.Value;
        public static implicit operator State<T>(T value) => new State<T>(value);
    }

    public class ValueChangedEvent<T>
    {
        public T OldValue { get; }

        public T NewValue { get; }

        public ValueChangedEvent(T oldValue, T newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
