using System;
using Meteoroid.Graphics.Metadata;

namespace Meteoroid.Graphics
{
    public class Container : IContainer
    {
        public Func<IWidget> Body { get; set; }
    }
}