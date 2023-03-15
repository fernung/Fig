using System;

namespace Fig.Graphics
{
    public class Canvas
    {
        public static readonly Canvas Empty = new();

        private readonly int _width;
        private readonly int _height;
        private readonly int _stride;
        private readonly Color[] _pixels;

        public int Width => _width;
        public int Height => _height;
        public int Stride => _stride;
        public int Length => _pixels.Length;
        public Span<Color> Pixels => _pixels.AsSpan();

        public Color this[int index]
        {
            get => GetPixel(index);
            set => SetPixel(index, value);
        }
        public Color this[int x, int y]
        {
            get => GetPixel(x, y);
            set => SetPixel(x, y, value);
        }

        public Canvas(int width, int height, Span<Color> pixels) :
            this(width, height)
        {
            pixels.Slice(0, Length).CopyTo(Pixels);
        }
        public Canvas(int width, int height)
        {
            _width = Math.Max(1, width);
            _height = Math.Max(1, height);
            _stride = _width << 2;
            _pixels = new Color[_width * _height];
        }
        private Canvas()
        {
            _width = 0;
            _height = 0;
            _stride = 0;
            _pixels = Array.Empty<Color>();
        }

        public Color GetPixel(int index)
        {
            if (InBounds(index, Length))
                return _pixels[index];
            return Color.Transparent;
        }
        public Color GetPixel(int x, int y)
        {
            if (InBounds(x, y, Width, Height))
                return _pixels[IndexOf(x, y, Width)];
            return Color.Transparent;
        }

        public void SetPixel(int index, Color color)
        {
            if (InBounds(index, Length))
                _pixels[index] = color;
        }
        public void SetPixel(int x, int y, Color color)
        {
            if (InBounds(x, y, Width, Height))
                _pixels[IndexOf(x, y, Width)] = color;
        }

        private static bool InBounds(int index, int length) =>
            0 <= index && index < length;
        private static bool InBounds(int x, int y, int width, int height) =>
            0 <= x && x < width && 0 <= y && y < height;
        private static int IndexOf(int x, int y, int width) =>
            x + y * width;
    }
}
