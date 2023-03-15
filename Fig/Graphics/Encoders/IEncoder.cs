using Fig.Graphics;

namespace Fig.Graphics.Encoders
{
    public interface IEncoder
    {
        void Encode(string filename, Canvas canvas);
    }
}
