using UnityEngine.Events;

namespace Meteoroid.Graphics.Metadata.Generic
{
    public interface IState<T> : IState
    {
        new T Value { get; set; }

        void AddListener(UnityAction<ValueChangedEvent<T>> call);

        void RemoveListener(UnityAction<ValueChangedEvent<T>> call);
    }
}
