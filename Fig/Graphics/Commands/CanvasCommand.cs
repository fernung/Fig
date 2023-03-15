namespace Fig.Graphics.Commands
{
    public class CanvasCommand : DrawCommand
    {
        public int SrcX;
        public int SrcY;
        public int SrcWidth;
        public int SrcHeight;
        public int DstX;
        public int DstY;
        public int DstWidth;
        public int DstHeight;
        public Canvas Canvas;
        public Color Color;
        private CanvasDrawMode _mode;

        public CanvasCommand(Canvas canvas, int x, int y) :
            this(canvas, x, y, Color.White)
        { }
        public CanvasCommand(Canvas canvas, int x, int y, Color color) :
            this(canvas, x, y, canvas.Width, canvas.Height, color)
        {
            _mode = CanvasDrawMode.Src;
        }
        public CanvasCommand(Canvas canvas, int x, int y, int width, int height) :
            this(canvas, x, y, width, height, Color.White)
        { }
        public CanvasCommand(Canvas canvas, int x, int y, int width, int height, Color color) :
            this(canvas, 0, 0, canvas.Width, canvas.Height, x, y, width, height, color)
        { 
            _mode = CanvasDrawMode.Dst;
        }
        public CanvasCommand(Canvas canvas, int srcX, int srcY, int srcWidth, int srcHeight, int dstX, int dstY, int dstWidth, int dstHeight) :
            this(canvas, srcX, srcY, srcWidth, srcHeight, dstX, dstY, dstWidth, dstHeight, Color.White)
        { }
        public CanvasCommand(Canvas canvas, int srcX, int srcY, int srcWidth, int srcHeight, int dstX, int dstY, int dstWidth, int dstHeight, Color color)
        {
            Canvas = canvas;
            SrcX = srcX;
            SrcY = srcY;
            SrcWidth = srcWidth;
            SrcHeight = srcHeight;
            DstX = dstX; 
            DstY = dstY;
            DstWidth = dstWidth;
            DstHeight = dstHeight;
            Color = color;
            _mode = CanvasDrawMode.SrcDst;
        }

        public override void Execute(Renderer renderer)
        {
            switch(_mode)
            {
                case CanvasDrawMode.Src:
                    renderer.DrawCanvas(Canvas, DstX, DstY, Color);
                    break;
                case CanvasDrawMode.Dst:
                    renderer.DrawCanvas(Canvas, DstX, DstY, DstWidth, DstHeight, Color);
                    break;
                case CanvasDrawMode.SrcDst:
                    renderer.DrawCanvas(Canvas, SrcX, SrcY, SrcWidth, SrcHeight, DstX, DstY, DstWidth, DstHeight, Color); 
                    break;
            }
        }
        public override bool Equals(DrawCommand other)
        {
            if (other == null || !(other is CanvasCommand))
                return false;

            CanvasCommand otherImage = (CanvasCommand)other;
            return SrcX == otherImage.SrcX &&
                   SrcY == otherImage.SrcY &&
                   SrcWidth == otherImage.SrcWidth &&
                   SrcHeight == otherImage.SrcHeight &&
                   DstX == otherImage.DstX &&
                   DstY == otherImage.DstY &&
                   DstWidth == otherImage.DstWidth &&
                   DstHeight == otherImage.DstHeight &&
                   Color == otherImage.Color &&
                   Canvas == otherImage.Canvas &&
                   _mode == otherImage._mode;
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + SrcX.GetHashCode();
            hash = hash * 31 + SrcY.GetHashCode();
            hash = hash * 31 + SrcWidth.GetHashCode();
            hash = hash * 31 + SrcHeight.GetHashCode();
            hash = hash * 31 + DstX.GetHashCode();
            hash = hash * 31 + DstY.GetHashCode();
            hash = hash * 31 + DstWidth.GetHashCode();
            hash = hash * 31 + DstHeight.GetHashCode();
            hash = hash * 31 + Color.GetHashCode();
            hash = hash * 31 + Canvas.GetHashCode();
            hash = hash * 31 + _mode.GetHashCode();
            return hash;
        }

        private enum CanvasDrawMode
        {
            Src,
            Dst,
            SrcDst
        }
    }
}
