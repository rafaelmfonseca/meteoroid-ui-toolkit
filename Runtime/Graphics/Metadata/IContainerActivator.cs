using System;

namespace Meteoroid.Graphics.Metadata
{
    internal interface IContainerActivator
    {
        IContainer CreateInstance(Type containerType);
    }
}
