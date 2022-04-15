namespace Meteoroid.Graphics.Metadata
{
    public class StateChangedEvent
    {
        public readonly string PropertyName;

        public StateChangedEvent(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}
