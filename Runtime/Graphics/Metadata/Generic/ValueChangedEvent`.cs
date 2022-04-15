namespace Meteoroid.Graphics.Metadata.Generic
{
    public class ValueChangedEvent<T>
    {
        public readonly IState<T> State;

        public readonly T OldValue;

        public readonly T NewValue;

        public ValueChangedEvent(IState<T> state, T oldValue, T newValue)
        {
            State = state;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
