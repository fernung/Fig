namespace Fig.Graphics.Commands
{
    public class TriangleCommand : DrawCommand
    {
        public int X1;
        public int Y1;
        public int X2;
        public int Y2;
        public int X3;
        public int Y3;
        public Color Color1;
        public Color Color2;
        public Color Color3;
        public bool Fill;

        public TriangleCommand(int x1, int y1, int x2, int y2, int x3, int y3, Color color) :
            this(x1, y1, x2, y2, x3, y3, color, false)
        { }
        public TriangleCommand(int x1, int y1, int x2, int y2, int x3, int y3, Color color, bool fill) :
            this(x1, y1, x2, y2, x3, y3, color, Color.Transparent, Color.Transparent)
        {
            Fill = fill;
        }
        public TriangleCommand(int x1, int y1, int x2, int y2, int x3, int y3, Color color1, Color color2, Color color3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
            Color1 = color1;
            Color2 = color2;
            Color3 = color3;
            Fill = true;
        }

        public override void Execute(Renderer renderer)
        {
            if(Fill)
            {
                if (Color2 == Color.Transparent || Color3 == Color.Transparent)
                    renderer.FillTriangle(X1, Y1, X2, Y2, X3, Y3, Color1);
                else renderer.FillTriangle(X1, Y1, X2, Y2, X3, Y3, Color1, Color2, Color3);
            }
            else renderer.DrawTriangle(X1, Y1, X2, Y2, X3, Y3, Color1);
        }
        public override bool Equals(DrawCommand other)
        {
            if (other == null || !(other is TriangleCommand))
                return false;
            TriangleCommand otherLine = (TriangleCommand)other;
            return X1 == otherLine.X1 &&
                   Y1 == otherLine.Y1 &&
                   X2 == otherLine.X2 &&
                   Y2 == otherLine.Y2 &&
                   X3 == otherLine.X3 &&
                   Y3 == otherLine.Y3 &&
                   Color1 == otherLine.Color1 &&
                   Color2 == otherLine.Color2 &&
                   Color3 == otherLine.Color3 &&
                   Fill == otherLine.Fill;
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + X1.GetHashCode();
            hash = hash * 31 + Y1.GetHashCode();
            hash = hash * 31 + X2.GetHashCode();
            hash = hash * 31 + Y2.GetHashCode();
            hash = hash * 31 + X3.GetHashCode();
            hash = hash * 31 + Y3.GetHashCode();
            hash = hash * 31 + Color1.GetHashCode();
            hash = hash * 31 + Color2.GetHashCode();
            hash = hash * 31 + Color3.GetHashCode();
            hash = hash * 31 + Fill.GetHashCode();
            return hash;
        }
    }
}
