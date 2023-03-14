namespace Fig.Decoders
{
    public interface IDecoder
    {
        Canvas Decode(string filename);
        void Decode(string filename, out Canvas canvas);
    }
}
