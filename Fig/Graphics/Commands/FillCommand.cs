namespace Fig.Graphics.Commands
{
    public class FillCommand : DrawCommand
    {
        public Color Color;

        public FillCommand() :
            this(Color.Transparent)
        { }
        public FillCommand(Color color)
        {
            Color = color;
        }

        public override void Execute(Renderer renderer)
        {
            renderer.Fill(Color);
        }
        public override bool Equals(DrawCommand other)
        {
            if (other == null || !(other is FillCommand))
                return false;

            FillCommand otherLine = (FillCommand)other;
            return Color == otherLine.Color;
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + Color.GetHashCode();
            return hash;
        }
    }
}
