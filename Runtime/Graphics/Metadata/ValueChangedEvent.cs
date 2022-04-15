namespace Meteoroid.Graphics.Metadata
{
    public class ValueChangedEvent
    {
        public readonly IState State;

        public readonly object OldValue;

        public readonly object NewValue;

        public ValueChangedEvent(IState state, object oldValue, object newValue)
        {
            State = state;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
