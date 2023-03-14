using System;
using System.IO;

namespace Fig.Decoders
{
    public class DecoderPPM : IDecoder
    {
        public Canvas Decode(string filename)
        {
            using var stream = File.OpenRead(filename);
            using var reader = new StreamReader(stream);

            // Read header
            var header = reader.ReadLine();
            if (header != "P3")
                throw new FormatException("Invalid PPM header");

            var size = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var width = int.Parse(size[0]);
            var height = int.Parse(size[1]);

            var maxValue = int.Parse(reader.ReadLine());

            // Read pixels
            var canvas = new Canvas(width, height);
            var pixels = canvas.Pixels;
            for (var i = 0; i < canvas.Length; i++)
            {
                var colorValues = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var r = byte.Parse(colorValues[0]);
                var g = byte.Parse(colorValues[1]);
                var b = byte.Parse(colorValues[2]);
                pixels[i] = new Color(r, g, b);
            }

            return canvas;
        }

        public void Decode(string filename, out Canvas canvas)
        {
            canvas = Decode(filename);
        }
    }
}
