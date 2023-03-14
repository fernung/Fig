using System;
using System.Runtime.InteropServices;

namespace Fig
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Color
    {
        [FieldOffset(0)] private int _bgra;
        [FieldOffset(0)] private uint _ubgra;
        [FieldOffset(0)] private byte _b;
        [FieldOffset(1)] private byte _g;
        [FieldOffset(2)] private byte _r;
        [FieldOffset(3)] private byte _a;

        public int BGRA { get => _bgra; set => _bgra = value; }
        public uint UBGRA { get => _ubgra; set => _ubgra = value; }

        public byte B { get => _b; set => _b = value; }
        public byte G { get => _g; set => _g = value; }
        public byte R { get => _r; set => _r = value; }
        public byte A { get => _a; set => _a = value; }

        public float Bf { get => ToFloat(_b); set => _b = ToByte(value); }
        public float Gf { get => ToFloat(_g); set => _g = ToByte(value); }
        public float Rf { get => ToFloat(_r); set => _r = ToByte(value); }
        public float Af { get => ToFloat(_a); set => _a = ToByte(value); }

        public Span<byte> Span =>
            MemoryMarshal.CreateSpan(ref _b, 4);

        public Color() :
            this(0)
        { }
        public Color(int bgra)
        {
            _bgra = bgra;
        }
        public Color(uint bgra)
        {
            _ubgra = bgra;
        }
        public Color(byte b, byte g, byte r, byte a = byte.MaxValue)
        {
            _b = b;
            _g = g;
            _r = r;
            _a = a;
        }
        public Color(float b, float g, float r, float a = 1f)
        {
            Bf = b;
            Gf = g;
            Rf = r;
            Af = a;
        }
        public Color(Span<byte> bgra)
        {
            _b = bgra.Length > 0 ? bgra[0] : default;
            _g = bgra.Length > 1 ? bgra[1] : default;
            _r = bgra.Length > 2 ? bgra[2] : default;
            _a = bgra.Length > 3 ? bgra[3] : byte.MaxValue;
        }

        public static Color Interpolate(Color c0, Color c1, float t)
        {
            var b = Interpolate(c0.Bf, c1.Bf, t);
            var g = Interpolate(c0.Gf, c1.Gf, t);
            var r = Interpolate(c0.Rf, c1.Rf, t);
            var a = Interpolate(c0.Af, c1.Af, t);
            return new(b, g, r, a);
        }
        public static Color Interpolate(Color c0, Color c1, Color c2, Color c3, float x, float y)
        {
            var b = Interpolate(c0.Bf, c1.Bf, c2.Bf, c3.Bf, x, y);
            var g = Interpolate(c0.Gf, c1.Gf, c2.Gf, c3.Gf, x, y);
            var r = Interpolate(c0.Rf, c1.Rf, c2.Rf, c3.Rf, x, y);
            var a = Interpolate(c0.Af, c1.Af, c2.Af, c3.Af, x, y);
            return new(b, g, r, a);
        }

        private static float ToFloat(byte value) =>
            value * (1f / 255f);
        private static byte ToByte(float value) =>
            (byte)(Math.Clamp(value, 0f, 1f) * 255f);
        private static float Interpolate(float a, float b, float t) =>
            a + (b - a) * t;
        private static float Interpolate(float a, float b, float c, float d, float x, float y) =>
            Interpolate(Interpolate(a, c, x), Interpolate(b, d, x), y);
        public static Color Interpolate(Color c0, Color c1, Color c2, float w0, float w1, float w2)
        {
            var b = InterpolateBarycentric(c0.Bf, c1.Bf, c2.Bf, w0, w1, w2);
            var g = InterpolateBarycentric(c0.Gf, c1.Gf, c2.Gf, w0, w1, w2);
            var r = InterpolateBarycentric(c0.Rf, c1.Rf, c2.Rf, w0, w1, w2);
            var a = InterpolateBarycentric(c0.Af, c1.Af, c2.Af, w0, w1, w2);
            return new(b, g, r, a);
        }

        private static float InterpolateBarycentric(float a, float b, float c, float w0, float w1, float w2)
        {
            return (a * w0) + (b * w1) + (c * w2);
        }

        public static implicit operator Color(int value) => new Color(value);
        public static implicit operator Color(uint value) => new Color(value);
        public static implicit operator int(Color value) => value._bgra;
        public static implicit operator uint(Color value) => value._ubgra;

        public static Color operator *(Color color, float multiplier)
        {
            return new Color(
                (byte)(color.R * multiplier),
                (byte)(color.G * multiplier),
                (byte)(color.B * multiplier),
                (byte)(color.A * multiplier)
            );
        }
        public static Color operator *(float multiplier, Color color) =>
            color * multiplier;
        public static Color operator +(Color a, Color b) =>
            new
            (
                (byte)Math.Min(a.R + b.R, 255),
                (byte)Math.Min(a.G + b.G, 255),
                (byte)Math.Min(a.B + b.B, 255),
                (byte)Math.Min(a.A + b.A, 255)
            );

        public static readonly Color Transparent = new();
        public static readonly Color White = new(0xFFFFFFFF);
        public static readonly Color Yellow = new(0xFFFFFF00);
        public static readonly Color Magenta = new(0xFFFF00FF);
        public static readonly Color Red = new(0xFFFF0000);
        public static readonly Color Cyan = new(0xFF00FFFF);
        public static readonly Color Green = new(0xFF00FF00);
        public static readonly Color Blue = new(0xFF0000FF);
        public static readonly Color Black = new(0xFF000000);
    }

    public static class ColorExtensions
    {
        public static Color NextColor(this Random random) =>
            random.Next() | (0xFF << 24);
        public static Color NextColorA(this Random random)
        {
            var bytes = new byte[4];
            random.NextBytes(bytes);
            return new(bytes.AsSpan());
        }
    }
}