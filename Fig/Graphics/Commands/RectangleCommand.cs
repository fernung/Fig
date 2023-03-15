namespace Fig.Graphics.Commands
{
    public class RectangleCommand : DrawCommand
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;
        public Color Color;
        public bool Fill;

        public RectangleCommand(int x, int y, int width, int height, Color color) :
            this(x, y, width, height, color, false)
        { }
        public RectangleCommand(int x, int y, int width, int height, Color color, bool fill)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Color = color;
            Fill = fill;
        }

        public override void Execute(Renderer renderer)
        {
            if (Fill) renderer.FillRectangle(X, Y, X + Width, Y + Height, Color);
            else renderer.DrawRectangle(X, Y, X + Width, Y + Height, Color);
        }
        public override bool Equals(DrawCommand other)
        {
            if (other == null || !(other is RectangleCommand))
                return false;
            RectangleCommand otherRect = (RectangleCommand)other;
            return X == otherRect.X &&
                   Y == otherRect.Y &&
                   Width == otherRect.Width &&
                   Height == otherRect.Height &&
                   Color == otherRect.Color &&
                   Fill == otherRect.Fill;
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + X.GetHashCode();
            hash = hash * 31 + Y.GetHashCode();
            hash = hash * 31 + Width.GetHashCode();
            hash = hash * 31 + Height.GetHashCode();
            hash = hash * 31 + Color.GetHashCode();
            hash = hash * 31 + Fill.GetHashCode();
            return hash;
        }
    }
}
