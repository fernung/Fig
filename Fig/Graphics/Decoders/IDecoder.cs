using Fig.Graphics;

namespace Fig.Graphics.Decoders
{
    public interface IDecoder
    {
        Canvas Decode(string filename);
        void Decode(string filename, out Canvas canvas);
    }
}
