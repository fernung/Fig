using System;
using System.Runtime.InteropServices;

namespace Fig.Encoders
{
    public class EncoderGDI : IEncoder
    {
        public void Encode(string filename, Canvas canvas)
        {
            var pixels = new Color[canvas.Length];
            canvas.Pixels.CopyTo(pixels.AsSpan());
            var handle = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            using var bitmap = new System.Drawing.Bitmap(canvas.Width, canvas.Height, canvas.Stride, System.Drawing.Imaging.PixelFormat.Format32bppArgb, handle.AddrOfPinnedObject());
            bitmap.Save(filename);
            bitmap.Dispose();
            handle.Free();
        }
    }
}
