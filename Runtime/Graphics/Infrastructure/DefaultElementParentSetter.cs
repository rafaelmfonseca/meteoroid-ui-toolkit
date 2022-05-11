using Meteoroid.Graphics.Metadata;
using UnityEngine;

namespace Meteoroid.Graphics.Infrastructure
{
    internal class DefaultElementParentSetter : IElementParentSetter
    {
        public void Update(GameObject parent, GameObject child)
        {
            child.transform.SetParent(parent.transform, worldPositionStays: false);
        }
    }
}
