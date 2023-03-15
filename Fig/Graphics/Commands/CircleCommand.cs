namespace Fig.Graphics.Commands
{
    public class CircleCommand : DrawCommand
    {
        public int X;
        public int Y;
        public int Radius;
        public Color Color;
        public bool Fill;

        public CircleCommand(int x, int y, int radius, Color color) :
            this(x, y, radius, color, false)
        { }
        public CircleCommand(int x, int y, int radius, Color color, bool fill)
        {
            X = x;
            Y = y;
            Radius = radius;
            Color = color;
            Fill = fill;
        }

        public override void Execute(Renderer renderer)
        {
            if(Fill) renderer.FillCircle(X, Y, Radius, Color);
            else renderer.DrawCircle(X, Y, Radius, Color);
        }
        public override bool Equals(DrawCommand other)
        {
            if (other == null || !(other is CircleCommand))
                return false;
            CircleCommand otherCircle = (CircleCommand)other;
            return X == otherCircle.X &&
                   Y == otherCircle.Y &&
                   Radius == otherCircle.Radius &&
                   Color == otherCircle.Color &&
                   Fill == otherCircle.Fill;
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + X.GetHashCode();
            hash = hash * 31 + Y.GetHashCode();
            hash = hash * 31 + Radius.GetHashCode();
            hash = hash * 31 + Color.GetHashCode();
            hash = hash * 31 + Fill.GetHashCode();
            return hash;
        }
    }
}
