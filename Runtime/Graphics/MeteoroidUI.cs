using UnityEngine;
using Meteoroid.Graphics.Metadata;
using Meteoroid.Graphics.Infrastructure;

namespace Meteoroid.Graphics
{
    public static class MeteoroidUI
    {
        private static readonly IContainerActivator _activator = new DefaultContainerActivator();

        public static IWidget Render<C>(GameObject parent) where C: IContainer, new()
        {
            return Render(_activator.CreateInstance(typeof(C)), parent);
        }

        public static IWidget Render(IContainer container, GameObject parent)
        {
            var body = container.Body();

            body.Element.transform.SetParent(parent.transform, worldPositionStays: false);

            return body;
        }
    }
}
