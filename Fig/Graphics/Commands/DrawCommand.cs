using System;

namespace Fig.Graphics.Commands
{
    public abstract class DrawCommand : IEquatable<DrawCommand>
    {
        public abstract void Execute(Renderer renderer);
        public abstract bool Equals(DrawCommand other);
        public abstract override int GetHashCode();
    }
}
