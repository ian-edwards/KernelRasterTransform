namespace KernelRasterTransform
{
    public class Raster
    {
        public int EdgeSize { get; private init; }

        readonly float[] _data;

        internal float Value(int x, int y) => _data[x + y * EdgeSize];

        public RasterKernel CreateKernel(int borderSize) => new(this, borderSize);

        internal Raster(int edgeSize, float[] data)
        {
            _data = data;
            EdgeSize = edgeSize;
        }
    }
}
