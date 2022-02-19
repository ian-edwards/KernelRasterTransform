namespace KernelRasterTransform
{
    public class SquareRaster
    {
        public int EdgeSize { get; private init; }

        readonly float[] _data;

        public float GetValue(int x, int y) => x < 0 || x >= EdgeSize || y < 0 || y >= EdgeSize
            ? float.NaN
            : _data[x + y * EdgeSize];

        public void SetValue(int x, int y, float value) => _data[x + y * EdgeSize] = value;

        public SquareRaster(int edgeSize)
        {
            if (edgeSize < 0) throw new ArgumentOutOfRangeException(nameof(edgeSize), "invalid negative");
            int size = edgeSize * edgeSize;

            _data = new float[size];
            EdgeSize = edgeSize;
        }

        internal SquareRaster(int edgeSize, float[] data)
        {
            if (data is null) throw new ArgumentNullException(nameof(data));
            if (edgeSize < 0) throw new ArgumentOutOfRangeException(nameof(edgeSize), "invalid negative");
            if (edgeSize * edgeSize != data.Length) throw new ArgumentException("data edge mismatch", nameof(edgeSize));

            _data = data;
            EdgeSize = edgeSize;
        }
    }
}
