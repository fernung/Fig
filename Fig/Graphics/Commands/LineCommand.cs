namespace Fig.Graphics.Commands
{
    public class LineCommand : DrawCommand
    {
        public int X1;
        public int Y1;
        public int X2;
        public int Y2;
        public Color Color;

        public LineCommand(int x1, int y1, int x2, int y2, Color color)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            Color = color;
        }

        public override void Execute(Renderer renderer)
        {
            renderer.DrawLine(X1, Y1, X2, Y2, Color);
        }
        public override bool Equals(DrawCommand other)
        {
            if (other == null || !(other is LineCommand))
                return false;

            LineCommand otherLine = (LineCommand)other;
            return X1 == otherLine.X1 &&
                   Y1 == otherLine.Y1 &&
                   X2 == otherLine.X2 &&
                   Y2 == otherLine.Y2 &&
                   Color == otherLine.Color;
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + X1.GetHashCode();
            hash = hash * 31 + Y1.GetHashCode();
            hash = hash * 31 + X2.GetHashCode();
            hash = hash * 31 + Y2.GetHashCode();
            hash = hash * 31 + Color.GetHashCode();
            return hash;
        }
    }
}
