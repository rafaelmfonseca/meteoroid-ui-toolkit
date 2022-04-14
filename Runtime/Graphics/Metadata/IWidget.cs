using UnityEngine;

namespace Meteoroid.Graphics.Metadata
{
    public interface IWidget
    {
        IWidget[] Children { get; set; }

        GameObject Element { get; set; }

        void NotifyPropertyChanged(string propertyName);

        void OnPropertyChanged(PropertyChangedEvent e);
    }

    public class PropertyChangedEvent
    {
        public string PropertyName { get; }

        public PropertyChangedEvent(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}
