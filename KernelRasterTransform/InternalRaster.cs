namespace KernelRasterTransform
{
    internal class InternalRaster : IRaster
    {
        public double[] Data { get; private init; }

        public int Width { get; private init; }

        public int Height { get; private init; }

        internal InternalRaster(double[] data, int width, int height)
        {
            Data = data;
            Width = width;
            Height = height;
        }
    }
}