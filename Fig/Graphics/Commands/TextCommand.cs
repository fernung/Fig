namespace Fig.Graphics.Commands
{
    public class TextCommand : DrawCommand
    {
        public string Text;
        public int X, Y;
        public Color Color;
        public int Size;

        public TextCommand(string text, int x, int y, Color color) :
            this(text, x, y, color, 0)
        { }
        public TextCommand(string text, int x, int y, Color color, int size)
        {
            Text = text;
            X = x;
            Y = y;
            Color = color;
            Size = size;
        }

        public override void Execute(Renderer renderer)
        {
            if(Size > 8) renderer.DrawText(Text, X, Y, Size, Color);
            else renderer.DrawText(Text, X, Y, Color);
        }
        public override bool Equals(DrawCommand other)
        {
            if (other == null || !(other is TextCommand))
                return false;

            TextCommand otherText = (TextCommand)other;
            return Text == otherText.Text &&
                   X == otherText.X &&
                   Y == otherText.Y &&
                   Color == otherText.Color &&
                   Size == otherText.Size;
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + Text.GetHashCode();
            hash = hash * 31 + X.GetHashCode();
            hash = hash * 31 + Y.GetHashCode();
            hash = hash * 31 + Color.GetHashCode();
            hash = hash * 31 + Size.GetHashCode();
            return hash;
        }
    }
}
