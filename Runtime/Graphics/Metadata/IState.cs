using UnityEngine.Events;

namespace Meteoroid.Graphics.Metadata
{
    public interface IState
    {
        object Value { get; set; }

        bool Disabled { get; set; }

        void AddListener(UnityAction<ValueChangedEvent> call);

        void RemoveListener(UnityAction<ValueChangedEvent> call);

        void RemoveAllListeners();
    }
}
