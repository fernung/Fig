using Fig.Decoders;
using Fig.Encoders;

namespace Fig.Runner
{
    internal class Program
    {
        private const string _dir = "C:\\Users\\fernu\\source\\repos\\Fig\\Fig.Runner\\Examples\\";
        private static readonly Canvas canvas = new(800, 600);
        private static readonly Graphics graphics = new(canvas);
        private static readonly IEncoder encoder = new EncoderBMP();
        private static readonly IDecoder decoder = new DecoderBMP();
        private static readonly Random random = new();

        static void Main(string[] args)
        {
            DrawTriangle();
            DrawRectangle();
            DrawCircle();
            DrawText();
            DrawCanvas();
            DrawTint();
        }

        static void DrawTriangle()
        {
            var colorBg = random.NextColor();
            var colorFg = random.NextColor();
            var x0 = random.Next(0, canvas.Width);
            var y0 = random.Next(0, canvas.Height);
            var x1 = random.Next(0, canvas.Width);
            var y1 = random.Next(0, canvas.Height);
            var x2 = random.Next(0, canvas.Width);
            var y2 = random.Next(0, canvas.Height);
            graphics.Fill(colorBg);
            graphics.DrawTriangle(x0, y0, x1, y1, x2, y2, colorFg);
            graphics.DrawText($"Triangle[({x0}, {y0}) -> ({x1}, {y1}) -> ({x2}, {y2})]", 0, 0, 16, Color.Black);
            encoder.Encode($"{_dir}triangle_draw.bmp", canvas);

            graphics.Fill(colorBg);
            graphics.FillTriangle(x0, y0, x1, y1, x2, y2, colorFg);
            graphics.DrawText($"Triangle[({x0}, {y0}) -> ({x1}, {y1}) -> ({x2}, {y2})]", 0, 0, 16, Color.Black);
            encoder.Encode($"{_dir}triangle_fill.bmp", canvas);
        }
        static void DrawRectangle()
        {
            var colorBg = random.NextColor();
            var colorFg = random.NextColor();
            var x0 = random.Next(0, canvas.Width);
            var y0 = random.Next(0, canvas.Height);
            var x1 = random.Next(0, canvas.Width);
            var y1 = random.Next(0, canvas.Height);
            graphics.Fill(colorBg);
            graphics.DrawRectangle(x0, y0, x1, y1, colorFg);
            graphics.DrawText($"Rectangle[({x0}, {y0}) -> ({x1}, {y1})]", 0, 0, 16, Color.Black);
            encoder.Encode($"{_dir}rectangle_draw.bmp", canvas);

            graphics.Fill(colorBg);
            graphics.FillRectangle(x0, y0, x1, y1, colorFg);
            graphics.DrawText($"Rectangle[({x0}, {y0}) -> ({x1}, {y1})]", 0, 0, 16, Color.Black);
            encoder.Encode($"{_dir}rectangle_fill.bmp", canvas);
        }
        static void DrawCircle()
        {
            var colorBg = random.NextColor();
            var colorFg = random.NextColor();
            var x0 = random.Next(0, canvas.Width);
            var y0 = random.Next(0, canvas.Height);
            var radius = random.Next(0, canvas.Width >> 2);
            graphics.Fill(colorBg);
            graphics.DrawCircle(x0, y0, radius, colorFg);
            graphics.DrawText($"Circle[({x0}, {y0}), r: {radius}]", 0, 0, 16, Color.Black);
            encoder.Encode($"{_dir}circle_draw.bmp", canvas);

            graphics.Fill(colorBg);
            graphics.FillCircle(x0, y0, radius, colorFg);
            graphics.DrawText($"Circle[({x0}, {y0}), r: {radius}]", 0, 0, 16, Color.Black);
            encoder.Encode($"{_dir}circle_fill.bmp", canvas);
        }
        static void DrawText()
        {
            var colorBg = random.NextColor();
            var colorFg = random.NextColor();
            graphics.Fill(colorBg);
            graphics.FillRectangle(200, 150, 600, 450, colorFg);
            graphics.DrawText("The quick brown fox jumped swiftly over the lazy dog.", 0, 0, 16, Color.Black);
            graphics.DrawText("THE QUICK BROWN FOX JUMPED SWIFTLY OVER THE LAZY DOG.", 0, 20, 16, Color.Black);
            encoder.Encode($"{_dir}text.bmp", canvas);
        }
        static void DrawCanvas()
        {
            var w = canvas.Width >> 1;
            var h = canvas.Height >> 1;
            Canvas c;
            graphics.Clear();
            decoder.Decode($"{_dir}triangle_fill.bmp", out c);
            graphics.DrawCanvas(c, 0, 0, w, h);
            decoder.Decode($"{_dir}rectangle_fill.bmp", out c);
            graphics.DrawCanvas(c, 400, 0, w, h);
            decoder.Decode($"{_dir}circle_fill.bmp", out c);
            graphics.DrawCanvas(c, 0, 300, w, h);
            decoder.Decode($"{_dir}text.bmp", out c);
            graphics.DrawCanvas(c, 400, 300, w, h);
            encoder.Encode($"{_dir}canvas.bmp", canvas);

            decoder.Decode($"{_dir}canvas.bmp", out c);
            graphics.Clear();
            graphics.DrawCanvas(c, 200, 150, 400, 300, 0, 0, canvas.Width, canvas.Height);
            encoder.Encode($"{_dir}canvas2.bmp", canvas);
        }
        static void DrawTint()
        {
            graphics.Fill(Color.Black);
            graphics.FillRectangle(200, 150, 600, 450, Color.White);
            encoder.Encode($"{_dir}tint.bmp", canvas);

            var w = canvas.Width >> 1;
            var h = canvas.Height >> 1;
            decoder.Decode($"{_dir}tint.bmp", out var c);
            graphics.DrawCanvas(c, 0, 0, w, h, Color.White);
            graphics.DrawCanvas(c, w, 0, w, h, Color.Red);
            graphics.DrawCanvas(c, 0, h, w, h, Color.Green);
            graphics.DrawCanvas(c, w, h, w, h, Color.Blue);
            encoder.Encode($"{_dir}tint.bmp", canvas);
        }
    }
}