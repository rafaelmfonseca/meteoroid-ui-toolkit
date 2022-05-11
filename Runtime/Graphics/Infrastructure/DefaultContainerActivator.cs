using Meteoroid.Graphics.Metadata;
using System;

namespace Meteoroid.Graphics.Infrastructure
{
    internal class DefaultContainerActivator : IContainerActivator
    {
        public IContainer CreateInstance(Type containerType)
        {
            if (containerType == null)
            {
                throw new ArgumentNullException(nameof(containerType));
            }

            if (!typeof(IContainer).IsAssignableFrom(containerType))
            {
                throw new ArgumentException($"The type {containerType.FullName} does not implement {nameof(IContainer)}.", nameof(containerType));
            }

            return (IContainer) Activator.CreateInstance(containerType)!;
        }
    }
}
