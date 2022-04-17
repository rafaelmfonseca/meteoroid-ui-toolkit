namespace Meteoroid.Graphics.Metadata
{
    public class ElementParentChangedEvent
    {
        public readonly IWidget NewParent;

        public ElementParentChangedEvent(IWidget newParent)
        {
            NewParent = newParent;
        }
    }
}
