using UnityEngine;

namespace Meteoroid.Graphics.Metadata
{
    internal interface IElementParentSetter
    {
        void Update(GameObject parent, GameObject child);
    }
}
