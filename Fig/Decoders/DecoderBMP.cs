using System;
using System.IO;

namespace Fig.Decoders
{
    public class DecoderBMP : IDecoder
    {
        private const int BMP_HEADER_SIZE = 14;
        private const int DIB_HEADER_SIZE = 40;
        private const int BYTES_PER_PIXEL = 4;

        public Canvas Decode(string filename)
        {
            using var stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            using var reader = new BinaryReader(stream);

            // Read BMP header
            reader.ReadBytes(BMP_HEADER_SIZE);

            // Read DIB header
            var dibHeaderSize = reader.ReadInt32();
            var width = reader.ReadInt32();
            var height = reader.ReadInt32();
            reader.ReadBytes(2); // planes
            var bitsPerPixel = reader.ReadInt16();

            if (bitsPerPixel != 24 && bitsPerPixel != 32)
                throw new NotSupportedException($"Unsupported bits per pixel: {bitsPerPixel}");

            // Create canvas and read pixel data
            var canvas = new Canvas(width, height);
            var pixels = canvas.Pixels;
            var rowLength = (int)Math.Ceiling(width * bitsPerPixel / 8.0);
            var paddingLength = (4 - (rowLength % 4)) % 4;
            var row = new byte[rowLength];

            for (var y = height - 1; y >= 0; y--)
            {
                reader.Read(row, 0, rowLength);

                for (var x = 0; x < width; x++)
                {
                    var index = x * BYTES_PER_PIXEL;
                    var offset = x * (bitsPerPixel / 8);
                    var b = row[offset];
                    var g = row[offset + 1];
                    var r = row[offset + 2];
                    var a = (bitsPerPixel == 24) ? byte.MaxValue : row[offset + 3];

                    pixels[y * width + x] = new Color(b, g, r, a);
                }

                reader.ReadBytes(paddingLength);
            }

            return canvas;
        }

        public void Decode(string filename, out Canvas canvas)
        {
            canvas = Decode(filename);
        }
    }
}
