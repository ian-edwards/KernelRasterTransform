namespace KernelRasterTransform
{
    public class Raster
    {
        public int Width { get; private init; }

        public int Height { get; private init; }

        readonly double[] _data;

        internal double Value(int x, int y) => _data[x + y * Width];

        internal Raster(int width, int height, double[] data)
        {
            _data = data;
            Width = width;
            Height = height;
        }
    }
}