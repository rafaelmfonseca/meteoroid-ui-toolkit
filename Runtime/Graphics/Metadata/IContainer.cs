using System;

namespace Meteoroid.Graphics.Metadata
{
    public interface IContainer
    {
        Func<IWidget> Body { get; set; }
    }
}
