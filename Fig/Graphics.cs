using System;

namespace Fig
{
    public class Graphics
    {
        private static readonly byte[,] _font = new byte[128, 8]
        {
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0000 (nul)
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0001
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0002
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0003
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0004
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0005
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0006
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0007
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0008
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0009
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+000A
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+000B
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+000C
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+000D
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+000E
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+000F
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0010
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0011
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0012
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0013
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0014
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0015
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0016
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0017
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0018
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0019
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+001A
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+001B
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+001C
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+001D
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+001E
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+001F
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0020 (space)
            { 0x18, 0x3C, 0x3C, 0x18, 0x18, 0x00, 0x18, 0x00},   // U+0021 (!)
            { 0x36, 0x36, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0022 (")
            { 0x36, 0x36, 0x7F, 0x36, 0x7F, 0x36, 0x36, 0x00},   // U+0023 (#)
            { 0x0C, 0x3E, 0x03, 0x1E, 0x30, 0x1F, 0x0C, 0x00},   // U+0024 ($)
            { 0x00, 0x63, 0x33, 0x18, 0x0C, 0x66, 0x63, 0x00},   // U+0025 (%)
            { 0x1C, 0x36, 0x1C, 0x6E, 0x3B, 0x33, 0x6E, 0x00},   // U+0026 (&)
            { 0x06, 0x06, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0027 (')
            { 0x18, 0x0C, 0x06, 0x06, 0x06, 0x0C, 0x18, 0x00},   // U+0028 (()
            { 0x06, 0x0C, 0x18, 0x18, 0x18, 0x0C, 0x06, 0x00},   // U+0029 ())
            { 0x00, 0x66, 0x3C, 0xFF, 0x3C, 0x66, 0x00, 0x00},   // U+002A (*)
            { 0x00, 0x0C, 0x0C, 0x3F, 0x0C, 0x0C, 0x00, 0x00},   // U+002B (+)
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x0C, 0x0C, 0x06},   // U+002C (,)
            { 0x00, 0x00, 0x00, 0x3F, 0x00, 0x00, 0x00, 0x00},   // U+002D (-)
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x0C, 0x0C, 0x00},   // U+002E (.)
            { 0x60, 0x30, 0x18, 0x0C, 0x06, 0x03, 0x01, 0x00},   // U+002F (/)
            { 0x3E, 0x63, 0x73, 0x7B, 0x6F, 0x67, 0x3E, 0x00},   // U+0030 (0)
            { 0x0C, 0x0E, 0x0C, 0x0C, 0x0C, 0x0C, 0x3F, 0x00},   // U+0031 (1)
            { 0x1E, 0x33, 0x30, 0x1C, 0x06, 0x33, 0x3F, 0x00},   // U+0032 (2)
            { 0x1E, 0x33, 0x30, 0x1C, 0x30, 0x33, 0x1E, 0x00},   // U+0033 (3)
            { 0x38, 0x3C, 0x36, 0x33, 0x7F, 0x30, 0x78, 0x00},   // U+0034 (4)
            { 0x3F, 0x03, 0x1F, 0x30, 0x30, 0x33, 0x1E, 0x00},   // U+0035 (5)
            { 0x1C, 0x06, 0x03, 0x1F, 0x33, 0x33, 0x1E, 0x00},   // U+0036 (6)
            { 0x3F, 0x33, 0x30, 0x18, 0x0C, 0x0C, 0x0C, 0x00},   // U+0037 (7)
            { 0x1E, 0x33, 0x33, 0x1E, 0x33, 0x33, 0x1E, 0x00},   // U+0038 (8)
            { 0x1E, 0x33, 0x33, 0x3E, 0x30, 0x18, 0x0E, 0x00},   // U+0039 (9)
            { 0x00, 0x0C, 0x0C, 0x00, 0x00, 0x0C, 0x0C, 0x00},   // U+003A (:)
            { 0x00, 0x0C, 0x0C, 0x00, 0x00, 0x0C, 0x0C, 0x06},   // U+003B (;)
            { 0x18, 0x0C, 0x06, 0x03, 0x06, 0x0C, 0x18, 0x00},   // U+003C (<)
            { 0x00, 0x00, 0x3F, 0x00, 0x00, 0x3F, 0x00, 0x00},   // U+003D (=)
            { 0x06, 0x0C, 0x18, 0x30, 0x18, 0x0C, 0x06, 0x00},   // U+003E (>)
            { 0x1E, 0x33, 0x30, 0x18, 0x0C, 0x00, 0x0C, 0x00},   // U+003F (?)
            { 0x3E, 0x63, 0x7B, 0x7B, 0x7B, 0x03, 0x1E, 0x00},   // U+0040 (@)
            { 0x0C, 0x1E, 0x33, 0x33, 0x3F, 0x33, 0x33, 0x00},   // U+0041 (A)
            { 0x3F, 0x66, 0x66, 0x3E, 0x66, 0x66, 0x3F, 0x00},   // U+0042 (B)
            { 0x3C, 0x66, 0x03, 0x03, 0x03, 0x66, 0x3C, 0x00},   // U+0043 (C)
            { 0x1F, 0x36, 0x66, 0x66, 0x66, 0x36, 0x1F, 0x00},   // U+0044 (D)
            { 0x7F, 0x46, 0x16, 0x1E, 0x16, 0x46, 0x7F, 0x00},   // U+0045 (E)
            { 0x7F, 0x46, 0x16, 0x1E, 0x16, 0x06, 0x0F, 0x00},   // U+0046 (F)
            { 0x3C, 0x66, 0x03, 0x03, 0x73, 0x66, 0x7C, 0x00},   // U+0047 (G)
            { 0x33, 0x33, 0x33, 0x3F, 0x33, 0x33, 0x33, 0x00},   // U+0048 (H)
            { 0x1E, 0x0C, 0x0C, 0x0C, 0x0C, 0x0C, 0x1E, 0x00},   // U+0049 (I)
            { 0x78, 0x30, 0x30, 0x30, 0x33, 0x33, 0x1E, 0x00},   // U+004A (J)
            { 0x67, 0x66, 0x36, 0x1E, 0x36, 0x66, 0x67, 0x00},   // U+004B (K)
            { 0x0F, 0x06, 0x06, 0x06, 0x46, 0x66, 0x7F, 0x00},   // U+004C (L)
            { 0x63, 0x77, 0x7F, 0x7F, 0x6B, 0x63, 0x63, 0x00},   // U+004D (M)
            { 0x63, 0x67, 0x6F, 0x7B, 0x73, 0x63, 0x63, 0x00},   // U+004E (N)
            { 0x1C, 0x36, 0x63, 0x63, 0x63, 0x36, 0x1C, 0x00},   // U+004F (O)
            { 0x3F, 0x66, 0x66, 0x3E, 0x06, 0x06, 0x0F, 0x00},   // U+0050 (P)
            { 0x1E, 0x33, 0x33, 0x33, 0x3B, 0x1E, 0x38, 0x00},   // U+0051 (Q)
            { 0x3F, 0x66, 0x66, 0x3E, 0x36, 0x66, 0x67, 0x00},   // U+0052 (R)
            { 0x1E, 0x33, 0x07, 0x0E, 0x38, 0x33, 0x1E, 0x00},   // U+0053 (S)
            { 0x3F, 0x2D, 0x0C, 0x0C, 0x0C, 0x0C, 0x1E, 0x00},   // U+0054 (T)
            { 0x33, 0x33, 0x33, 0x33, 0x33, 0x33, 0x3F, 0x00},   // U+0055 (U)
            { 0x33, 0x33, 0x33, 0x33, 0x33, 0x1E, 0x0C, 0x00},   // U+0056 (V)
            { 0x63, 0x63, 0x63, 0x6B, 0x7F, 0x77, 0x63, 0x00},   // U+0057 (W)
            { 0x63, 0x63, 0x36, 0x1C, 0x1C, 0x36, 0x63, 0x00},   // U+0058 (X)
            { 0x33, 0x33, 0x33, 0x1E, 0x0C, 0x0C, 0x1E, 0x00},   // U+0059 (Y)
            { 0x7F, 0x63, 0x31, 0x18, 0x4C, 0x66, 0x7F, 0x00},   // U+005A (Z)
            { 0x1E, 0x06, 0x06, 0x06, 0x06, 0x06, 0x1E, 0x00},   // U+005B ([)
            { 0x03, 0x06, 0x0C, 0x18, 0x30, 0x60, 0x40, 0x00},   // U+005C (\)
            { 0x1E, 0x18, 0x18, 0x18, 0x18, 0x18, 0x1E, 0x00},   // U+005D (])
            { 0x08, 0x1C, 0x36, 0x63, 0x00, 0x00, 0x00, 0x00},   // U+005E (^)
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF},   // U+005F (_)
            { 0x0C, 0x0C, 0x18, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+0060 (`)
            { 0x00, 0x00, 0x1E, 0x30, 0x3E, 0x33, 0x6E, 0x00},   // U+0061 (a)
            { 0x07, 0x06, 0x06, 0x3E, 0x66, 0x66, 0x3B, 0x00},   // U+0062 (b)
            { 0x00, 0x00, 0x1E, 0x33, 0x03, 0x33, 0x1E, 0x00},   // U+0063 (c)
            { 0x38, 0x30, 0x30, 0x3e, 0x33, 0x33, 0x6E, 0x00},   // U+0064 (d)
            { 0x00, 0x00, 0x1E, 0x33, 0x3f, 0x03, 0x1E, 0x00},   // U+0065 (e)
            { 0x1C, 0x36, 0x06, 0x0f, 0x06, 0x06, 0x0F, 0x00},   // U+0066 (f)
            { 0x00, 0x00, 0x6E, 0x33, 0x33, 0x3E, 0x30, 0x1F},   // U+0067 (g)
            { 0x07, 0x06, 0x36, 0x6E, 0x66, 0x66, 0x67, 0x00},   // U+0068 (h)
            { 0x0C, 0x00, 0x0E, 0x0C, 0x0C, 0x0C, 0x1E, 0x00},   // U+0069 (i)
            { 0x30, 0x00, 0x30, 0x30, 0x30, 0x33, 0x33, 0x1E},   // U+006A (j)
            { 0x07, 0x06, 0x66, 0x36, 0x1E, 0x36, 0x67, 0x00},   // U+006B (k)
            { 0x0E, 0x0C, 0x0C, 0x0C, 0x0C, 0x0C, 0x1E, 0x00},   // U+006C (l)
            { 0x00, 0x00, 0x33, 0x7F, 0x7F, 0x6B, 0x63, 0x00},   // U+006D (m)
            { 0x00, 0x00, 0x1F, 0x33, 0x33, 0x33, 0x33, 0x00},   // U+006E (n)
            { 0x00, 0x00, 0x1E, 0x33, 0x33, 0x33, 0x1E, 0x00},   // U+006F (o)
            { 0x00, 0x00, 0x3B, 0x66, 0x66, 0x3E, 0x06, 0x0F},   // U+0070 (p)
            { 0x00, 0x00, 0x6E, 0x33, 0x33, 0x3E, 0x30, 0x78},   // U+0071 (q)
            { 0x00, 0x00, 0x3B, 0x6E, 0x66, 0x06, 0x0F, 0x00},   // U+0072 (r)
            { 0x00, 0x00, 0x3E, 0x03, 0x1E, 0x30, 0x1F, 0x00},   // U+0073 (s)
            { 0x08, 0x0C, 0x3E, 0x0C, 0x0C, 0x2C, 0x18, 0x00},   // U+0074 (t)
            { 0x00, 0x00, 0x33, 0x33, 0x33, 0x33, 0x6E, 0x00},   // U+0075 (u)
            { 0x00, 0x00, 0x33, 0x33, 0x33, 0x1E, 0x0C, 0x00},   // U+0076 (v)
            { 0x00, 0x00, 0x63, 0x6B, 0x7F, 0x7F, 0x36, 0x00},   // U+0077 (w)
            { 0x00, 0x00, 0x63, 0x36, 0x1C, 0x36, 0x63, 0x00},   // U+0078 (x)
            { 0x00, 0x00, 0x33, 0x33, 0x33, 0x3E, 0x30, 0x1F},   // U+0079 (y)
            { 0x00, 0x00, 0x3F, 0x19, 0x0C, 0x26, 0x3F, 0x00},   // U+007A (z)
            { 0x38, 0x0C, 0x0C, 0x07, 0x0C, 0x0C, 0x38, 0x00},   // U+007B ({)
            { 0x18, 0x18, 0x18, 0x00, 0x18, 0x18, 0x18, 0x00},   // U+007C (|)
            { 0x07, 0x0C, 0x0C, 0x38, 0x0C, 0x0C, 0x07, 0x00},   // U+007D (})
            { 0x6E, 0x3B, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},   // U+007E (~)
            { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}    // U+007F
        };
        private Canvas _canvas;

        public Canvas Canvas
        {
            get => _canvas;
            set => _canvas = value;
        }

        public Graphics(int width, int height) :
            this(new(width, height))
        { }
        public Graphics(Canvas canvas)
        {
            _canvas = canvas;
        }

        public void Clear() =>
            Fill(Color.Transparent);
        public void Fill(Color color) =>
            _canvas.Pixels.Fill(color);

        public void DrawPixel(int x, int y, Color color) =>
            _canvas[x, y] = color;
        public void DrawLine(int x0, int y0, int x1, int y1, Color color)
        {
            bool steep = Math.Abs(x0 - x1) < Math.Abs(y0 - y1);
            if(steep)
            {
                (x0, y0) = (y0, x0);
                (x1, y1) = (y1, x1);
            }
            if(x0 > x1)
            {
                (x0, x1) = (x1, x0);
                (y0, y1) = (y1, y0);
            }

            int dx = x1 - x0, dy = y1 - y0;
            int x = x0, xInc = dx << 1;
            int y = y0, yInc = y1 > y0 ? 1 : -1;
            int error = 0, errorInc = Math.Abs(dy) << 1;
            for (; x <= x1; x++)
            {
                if (steep) _canvas[y, x] = color;
                else _canvas[x, y] = color;
                error += errorInc;
                if (error > dx)
                {
                    y += yInc;
                    error -= xInc;
                }
            }
        }
        public void DrawTriangle(int x0, int y0, int x1, int y1, int x2, int y2, Color color)
        {
            if (y0 == y1 && y0 == y2) 
                return;
            if (y0 > y1)
            {
                (x0, x1) = (x1, x0);
                (y0, y1) = (y1, y0);
            }
            if (y0 > y2)
            {
                (x0, x2) = (x2, x0);
                (y0, y2) = (y2, y0);
            }
            if (y1 > y2)
            {
                (x1, x2) = (x2, x1);
                (y1, y2) = (y2, y1);
            }
            DrawLine(x0, y0, x1, y1, color);
            DrawLine(x1, y1, x2, y2, color);
            DrawLine(x2, y2, x0, y0, color);
        }
        public void DrawRectangle(int x0, int y0, int x1, int y1, Color color)
        {
            if(x0 > x1)
            {
                (x0, x1) = (x1, x0);
                (y0, y1) = (y1, y0);
            }
            if(y0 > y1)
            {
                (y0, y1) = (y1, y0);
            }

            int index, x, y;
            for (x = x0; x <= x1; x++)
            {
                y = y0;
                index = x + y * _canvas.Width;
                _canvas[index] = color;
                y = y1;
                index = x + y * _canvas.Width;
                _canvas[index] = color;
            }
            for (y = y0; y <= y1; y++)
            {
                x = x0;
                index = x + y * _canvas.Width;
                _canvas[index] = color;
                x = x1;
                index = x + y * _canvas.Width;
                _canvas[index] = color;
            }
        }
        public void DrawCircle(int x, int y, int radius, Color color)
        {
            int d = 3 - 2 * radius;
            int i = 0;
            int j = radius;
            while (i <= j)
            {
                _canvas[x + i, y + j] = color;
                _canvas[x + j, y + i] = color;
                _canvas[x + j, y - i] = color;
                _canvas[x + i, y - j] = color;
                _canvas[x - i, y - j] = color;
                _canvas[x - j, y - i] = color;
                _canvas[x - j, y + i] = color;
                _canvas[x - i, y + j] = color;
                if (d < 0)
                    d += 4 * i + 6;
                else
                {
                    d += 4 * (i - j) + 10;
                    j--;
                }
                i++;
            }
        }

        public void DrawText(string text, int x, int y, Color color)
        {
            byte glyph;
            int i, j, index = 0;
            foreach (var c in text)
            {
                if (c >= 128)
                    continue;
                for (i = 0; i < 8; i++)
                {
                    glyph = _font[c, i];
                    for (j = 0; j < 8; j++)
                        if ((glyph & (1 << j)) != 0)
                            _canvas[x + index + j, y + i] = color;
                }
                index += 8;
            }
        }
        public void DrawText(string text, int x, int y, int size, Color color)
        {
            int i, j, k, l, index = 0;
            float scale = (float)size / 8f;
            foreach (var c in text)
            {
                if (c >= 128)
                    continue;
                for (i = 0; i < 8; i++)
                {
                    byte glyph = _font[c, i];
                    for (j = 0; j < 8; j++)
                    {
                        if ((glyph & (1 << j)) != 0)
                        {
                            for (k = 0; k < scale; k++)
                            {
                                int yIndex = (int)(y + i * scale + k);
                                if (yIndex >= _canvas.Height)
                                    break;
                                for (l = 0; l < scale; l++)
                                {
                                    int xIndex = (int)(x + index + j * scale + l);
                                    if (xIndex >= _canvas.Width)
                                        break;
                                    _canvas[xIndex, yIndex] = color;
                                }
                            }
                        }
                    }
                }
                index += (int)(8 * scale);
            }
        }

        public void DrawCanvas(Canvas canvas, int x, int y) =>
            DrawCanvas(canvas, x, y, Color.White);
        public void DrawCanvas(Canvas canvas, int x, int y, Color color)
        {
            Color c;
            int canvasX, canvasY;
            int xEnd = Math.Min(x + canvas.Width, _canvas.Width);
            int yEnd = Math.Min(y + canvas.Height, _canvas.Height);
            for (int i = y; i < yEnd; i++)
            {
                canvasY = i - y;
                for (int j = x; j < xEnd; j++)
                {
                    canvasX = j - x;
                    c = (canvas[canvasX, canvasY].UBGRA & color.UBGRA);
                    _canvas[j, i] = (c.A == byte.MaxValue) ? c : BlendColors(_canvas[j, i], c);
                }
            }
        }
        public void DrawCanvas(Canvas canvas, int x, int y, int width, int height) =>
            DrawCanvas(canvas, x, y, width, height, Color.White);
        public void DrawCanvas(Canvas canvas, int x, int y, int width, int height, Color color)
        {
            Color c;
            float uStep = (float)(canvas.Width - 1)/ width;
            float vStep = (float)(canvas.Height- 1) / height;

            int xEnd = Math.Min(x + width, _canvas.Width - 1);
            int yEnd = Math.Min(y + height, _canvas.Height - 1);

            for (int i = y; i < yEnd; i++)
            {
                float v = (i - y) * vStep;
                int canvasY1 = (int)v;
                int canvasY2 = Math.Min(canvasY1 + 1, canvas.Height - 1);
                float vLerp = v - canvasY1;

                for (int j = x; j < xEnd; j++)
                {
                    float u = (j - x) * uStep;
                    int canvasX1 = (int)u;
                    int canvasX2 = Math.Min(canvasX1 + 1, canvas.Width - 1);
                    float uLerp = u - canvasX1;
                    c = (Color.Interpolate
                    (
                        canvas[canvasX1, canvasY1],
                        canvas[canvasX2, canvasY1],
                        canvas[canvasX1, canvasY2],
                        canvas[canvasX2, canvasY2],
                        uLerp, vLerp
                    ).UBGRA & color.UBGRA);
                    _canvas[j, i] = (c.A == byte.MaxValue) ? c : BlendColors(_canvas[j, i], c);
                }
            }
        }
        public void DrawCanvas(Canvas canvas, int srcX, int srcY, int srcW, int srcH, int dstX, int dstY, int dstW, int dstH) =>
            DrawCanvas(canvas, srcX, srcY, srcW, srcH, dstX, dstY, dstW, dstH, Color.White);
        public void DrawCanvas(Canvas canvas, int srcX, int srcY, int srcW, int srcH, int dstX, int dstY, int dstW, int dstH, Color color)
        {
            Color c;
            int canvasX, canvasY;
            float uStep = (float)srcW / dstW;
            float vStep = (float)srcH / dstH;

            int xEnd = Math.Min(dstX + dstW, _canvas.Width - 1);
            int yEnd = Math.Min(dstY + dstH, _canvas.Height - 1);

            for (int i = dstY; i < yEnd; i++)
            {
                float v = (i - dstY) * vStep + srcY;
                int canvasY1 = (int)v;
                float vLerp = v - canvasY1;

                for (int j = dstX; j < xEnd; j++)
                {
                    float u = (j - dstX) * uStep + srcX;
                    int canvasX1 = (int)u;
                    float uLerp = u - canvasX1;

                    // Use nearest neighbor interpolation
                    canvasX = (uLerp < 0.5f) ? canvasX1 : canvasX1 + 1;
                    canvasY = (vLerp < 0.5f) ? canvasY1 : canvasY1 + 1;
                    c = (canvas[canvasX, canvasY].UBGRA & color.UBGRA);
                    _canvas[j, i] = (c.A == byte.MaxValue) ? c : BlendColors(_canvas[j, i], c);
                }
            }
        }

        public void FillTriangle(int x0, int y0, int x1, int y1, int x2, int y2, Color color)
        {
            if (color.A != byte.MaxValue)
            {
                BlendTriangle(x0, y0, x1, y1, x2, y2, color);
                return;
            }

            var minX = Math.Min(x0, Math.Min(x1, x2));
            var minY = Math.Min(y0, Math.Min(y1, y2));
            var maxX = Math.Max(x0, Math.Max(x1, x2));
            var maxY = Math.Max(y0, Math.Max(y1, y2));
            for (var y = minY; y <= maxY; y++)
                for (var x = minX; x <= maxX; x++)
                {
                    if (!IsInsideTriangle(x, y, x0, y0, x1, y1, x2, y2))
                        continue;
                    _canvas[x, y] = color;
                }
        }
        public void FillTriangle(int x0, int y0, int x1, int y1, int x2, int y2, Color c0, Color c1, Color c2)
        {
            var minX = Math.Min(x0, Math.Min(x1, x2));
            var minY = Math.Min(y0, Math.Min(y1, y2));
            var maxX = Math.Max(x0, Math.Max(x1, x2));
            var maxY = Math.Max(y0, Math.Max(y1, y2));

            float denom = ((y1 - y2) * (x0 - x2) + (x2 - x1) * (y0 - y2));
            if (denom == 0) denom = 1;

            for (var y = minY; y <= maxY; y++)
            {
                for (var x = minX; x <= maxX; x++)
                {
                    float w0 = ((y1 - y2) * (x - x2) + (x2 - x1) * (y - y2)) / denom;
                    float w1 = ((y2 - y0) * (x - x2) + (x0 - x2) * (y - y2)) / denom;
                    float w2 = 1f - w0 - w1;

                    if (w0 >= 0f && w1 >= 0f && w2 >= 0f)
                    {
                        Color interpolatedColor = Color.Interpolate(c0, c1, c2, w0, w1, w2);
                        _canvas[x, y] = interpolatedColor.A == byte.MaxValue ? 
                                        interpolatedColor : 
                                        BlendColors(_canvas[x, y], interpolatedColor);
                    }
                }
            }
        }
        public void FillRectangle(int x0, int y0, int x1, int y1, Color color)
        {
            if (color.A != byte.MaxValue)
            {
                BlendRectangle(x0, y0, x1, y1, color);
                return;
            }

            var minX = Math.Min(x0, x1);
            var minY = Math.Min(y0, y1);
            var maxX = Math.Max(x0, x1);
            var maxY = Math.Max(y0, y1);
            for (var y = minY; y <= maxY; y++)
                for (var x = minX; x <= maxX; x++)
                    _canvas[x, y] = color;
        }
        public void FillCircle(int x, int y, int radius, Color color)
        {
            if (color.A != byte.MaxValue)
            {
                BlendCircle(x, y, radius, color);
                return;
            }

            var r2 = radius * radius;
            for (var ys = -radius; ys <= radius; ys++)
                for (var xs = -radius; xs <= radius; xs++)
                    if (xs * xs + ys * ys <= r2)
                        _canvas[x + xs, y + ys] = color;
        }

        public void BlendTriangle(int x0, int y0, int x1, int y1, int x2, int y2, Color color)
        {
            var minX = Math.Min(x0, Math.Min(x1, x2));
            var minY = Math.Min(y0, Math.Min(y1, y2));
            var maxX = Math.Max(x0, Math.Max(x1, x2));
            var maxY = Math.Max(y0, Math.Max(y1, y2));
            for (var y = minY; y <= maxY; y++)
                for (var x = minX; x <= maxX; x++)
                {
                    if (!IsInsideTriangle(x, y, x0, y0, x1, y1, x2, y2))
                        continue;
                    _canvas[x, y] = BlendColors(_canvas[x, y], color);
                }
        }
        public void BlendRectangle(int x0, int y0, int x1, int y1, Color color)
        {
            var minX = Math.Min(x0, x1);
            var minY = Math.Min(y0, y1);
            var maxX = Math.Max(x0, x1);
            var maxY = Math.Max(y0, y1);
            for (var y = minY; y <= maxY; y++)
                for (var x = minX; x <= maxX; x++)
                    _canvas[x, y] = BlendColors(_canvas[x, y], color);
        }
        public void BlendCircle(int x, int y, int radius, Color color)
        {
            var r2 = radius * radius;
            for (var ys = -radius; ys <= radius; ys++)
                for (var xs = -radius; xs <= radius; xs++)
                    if (xs * xs + ys * ys <= r2)
                        _canvas[x + xs, y + ys] = BlendColors(_canvas[x + xs, y + ys], color);
        }

        private static bool IsInsideTriangle(int pX, int pY, int x0, int y0, int x1, int y1, int x2, int y2)
        {
            float w0_denom = ((y1 - y2) * (x0 - x2) + (x2 - x1) * (y0 - y2));
            float w1_denom = ((y1 - y2) * (x0 - x2) + (x2 - x1) * (y0 - y2));
            if (w0_denom == 0) w0_denom = 1;
            if (w1_denom == 0) w1_denom = 1;
            float w0 = ((y1 - y2) * (pX - x2) + (x2 - x1) * (pY - y2)) /
                       w0_denom;
            float w1 = ((y2 - y0) * (pX - x2) + (x0 - x2) * (pY - y2)) /
                       w1_denom;
            float w2 = 1 - w0 - w1;
            return w0 >= 0 && w1 >= 0 && w2 >= 0;
        }
        private static Color BlendColors(Color dst, Color src)
        {
            float srcA = src.Af;
            float dstA = dst.Af;
            float outA = srcA + dstA * (1.0f - srcA);

            if (outA == 0)
                return new Color(0, 0, 0, 0);

            float outR = (src.Rf * srcA + dst.Rf * dstA * (1 - srcA)) / outA;
            float outG = (src.Gf * srcA + dst.Gf * dstA * (1 - srcA)) / outA;
            float outB = (src.Bf * srcA + dst.Bf * dstA * (1 - srcA)) / outA;

            return new Color(outB, outG, outR, outA);
        }
    }
}
