using UnityEngine;

namespace Meteoroid.Graphics.Metadata
{
    public interface IWidget
    {
        IWidget[] Children { get; set; }

        GameObject Element { get; set; }

        void RegistryPropertyState<T>(ref T newValue, string propertyName, IState newState);

        void OnStateChanged(StateChangedEvent e);

        void OnParentChanged(ElementParentChangedEvent e);
    }
}
