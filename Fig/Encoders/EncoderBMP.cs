using System;
using System.IO;

namespace Fig.Encoders
{
    public class EncoderBMP : IEncoder
    {
        private const int BMP_HEADER_SIZE = 14;
        private const int DIB_HEADER_SIZE = 40;

        public void Encode(string filename, Canvas canvas)
        {
            using var stream = new FileStream(filename, FileMode.Create, FileAccess.Write);
            using var writer = new BinaryWriter(stream);

            // Calculate row length and padding length
            var width = canvas.Width;
            var height = canvas.Height;
            var bitsPerPixel = 32;
            var rowLength = width * bitsPerPixel / 8;
            var paddingLength = (4 - (rowLength % 4)) % 4;

            // Write BMP header
            writer.Write((short)0x4D42);
            writer.Write(BMP_HEADER_SIZE + DIB_HEADER_SIZE + (rowLength + paddingLength) * height);
            writer.Write((short)0);
            writer.Write((short)0);
            writer.Write(BMP_HEADER_SIZE + DIB_HEADER_SIZE);

            // Write DIB header
            writer.Write(DIB_HEADER_SIZE);
            writer.Write(width);
            writer.Write(height);
            writer.Write((short)1);
            writer.Write((short)bitsPerPixel);
            writer.Write(0);
            writer.Write(rowLength * height + paddingLength * height);
            writer.Write((short)0);
            writer.Write((short)0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);

            // Write pixel data
            var pixels = canvas.Pixels;
            var row = new byte[rowLength];
            for (var y = height - 1; y >= 0; y--)
            {
                for (var x = 0; x < width; x++)
                {
                    var index = y * width + x;
                    var color = pixels[index];

                    // Convert Color struct to little-endian BGRA format
                    row[x * 4] = color.B;
                    row[x * 4 + 1] = color.G;
                    row[x * 4 + 2] = color.R;
                    row[x * 4 + 3] = color.A;
                }

                writer.Write(row, 0, rowLength);
                writer.Write(new byte[paddingLength]);
            }
        }
    }
}
