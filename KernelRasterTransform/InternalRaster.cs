namespace KernelRasterTransform
{
    internal class InternalRaster : IRaster
    {
        public int Width { get; private init; }

        public int Height { get; private init; }

        readonly double[] _data;

        public double Value(int x, int y) => _data[x + y * Width];

        internal InternalRaster(double[] data, int width, int height)
        {
            _data = data;
            Width = width;
            Height = height;
        }
    }
}