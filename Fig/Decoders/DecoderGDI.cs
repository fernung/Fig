using System;
using System.Runtime.InteropServices;

namespace Fig.Decoders
{
    public class DecoderGDI : IDecoder
    {
        public Canvas Decode(string filename)
        {
            using var bitmap = System.Drawing.Image.FromFile(filename) as System.Drawing.Bitmap;
            var rect = new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height);
            var data = bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var bytes = new byte[(rect.Width * rect.Height) << 2];
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
            bitmap.UnlockBits(data);
            bitmap.Dispose();
            var pixels = new Color[bytes.Length >> 2];
            Buffer.BlockCopy(bytes, 0, pixels, 0, bytes.Length);
            return new(rect.Width, rect.Height, pixels.AsSpan());
        }

        public void Decode(string filename, out Canvas canvas)
        {
            canvas = Decode(filename);
        }
    }
}
