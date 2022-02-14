namespace KernelRasterTransform
{
    public class MeanKernelTransform
    {
        public int RadiusSize { get; private init; }

        readonly int edgeSize;

        readonly int size;

        public MeanKernelTransform(int radiusSize)
        {
            if (radiusSize < 0) throw new ArgumentOutOfRangeException(nameof(radiusSize), "invalid negative");
            RadiusSize = radiusSize;
            edgeSize = RadiusSize * 2 + 1;
            size = edgeSize * edgeSize;
        }

        public float? Transform(SquareRaster raster, int x, int y)
        {
            bool hasResult = false;
            float result = 0;
            for (int yn = 0, yi = y - RadiusSize; yn < edgeSize; yn++, yi++)
            {
                for (int xn = 0, xi = x - RadiusSize; xn < edgeSize; xn++, xi++)
                {
                    float? value = raster.GetValue(xi, yi);
                    result += value ?? 0;
                    hasResult = value.HasValue;
                }
            }
            return hasResult ? result / size : null;
        }
    }
}
