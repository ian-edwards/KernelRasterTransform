namespace KernelRasterTransform
{
    public struct RasterValue
    {
        public double Value { get; private init; }

        public int X { get; private init; }

        public int Y { get; private init; }

        internal RasterValue(double value, int x, int y)
        {
            Value = value;
            X = x;
            Y = y;
        }
    }
}
