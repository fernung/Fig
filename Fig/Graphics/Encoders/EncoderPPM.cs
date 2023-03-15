using System.IO;
using Fig.Graphics;

namespace Fig.Graphics.Encoders
{
    public class EncoderPPM : IEncoder
    {
        public void Encode(string filename, Canvas canvas)
        {
            if (!Path.HasExtension(filename) ||
                 Path.GetExtension(filename).ToLower() != "ppm")
                filename = $"{filename}.ppm";
            using var stream = File.OpenWrite(filename);
            using var writer = new StreamWriter(stream);

            writer.WriteLine("P3");
            writer.WriteLine($"{canvas.Width} {canvas.Height}");
            writer.WriteLine("255");

            var pixels = canvas.Pixels;
            for (var i = 0; i < canvas.Length; i++)
            {
                var color = pixels[i];
                writer.Write($"{color.R} {color.G} {color.B} ");
                if (i % canvas.Width == canvas.Width - 1)
                    writer.WriteLine();
            }
        }
    }
}
