﻿namespace KernelRasterTransform
{
    public class Raster
    {
        public int EdgeSize { get; private init; }

        readonly float?[] _data;

        public float? GetValue(int x, int y) => _data[x + y * EdgeSize];

        public void SetValue(int x, int y, float? value) => _data[x + y * EdgeSize] = value;

        public Raster(int edgeSize)
        {
            if (edgeSize < 0) throw new ArgumentOutOfRangeException(nameof(edgeSize), "invalid negative");
            int size = edgeSize * edgeSize;

            _data = new float?[size];
            EdgeSize = edgeSize;
        }

        internal Raster(int edgeSize, float?[] data)
        {
            if (data is null) throw new ArgumentNullException(nameof(data));
            if (edgeSize < 0) throw new ArgumentOutOfRangeException(nameof(edgeSize), "invalid negative");
            if (edgeSize * edgeSize != data.Length) throw new ArgumentException("not expected square", nameof(edgeSize));

            _data = data;
            EdgeSize = edgeSize;
        }
    }
}
