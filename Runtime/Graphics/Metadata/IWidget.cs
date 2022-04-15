using UnityEngine;

namespace Meteoroid.Graphics.Metadata
{
    public interface IWidget
    {
        IWidget[] Children { get; set; }

        GameObject Element { get; set; }

        void RegistryPropertyState(string propertyName, IState state);

        void OnStateChanged(StateChangedEvent e);
    }
}
