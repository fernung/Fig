namespace Fig.Graphics.Commands
{
    public class PixelCommand : DrawCommand
    {
        public int X;
        public int Y;
        public Color Color;

        public PixelCommand(int x, int y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        public override void Execute(Renderer renderer)
        {
            renderer.DrawPixel(X, Y, Color);
        }
        public override bool Equals(DrawCommand other)
        {
            if (other == null || !(other is PixelCommand))
                return false;

            PixelCommand otherLine = (PixelCommand)other;
            return X == otherLine.X &&
                   Y == otherLine.Y &&
                   Color == otherLine.Color;
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + X.GetHashCode();
            hash = hash * 31 + Y.GetHashCode();
            hash = hash * 31 + Color.GetHashCode();
            return hash;
        }
    }
}
