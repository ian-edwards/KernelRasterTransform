namespace KernelRasterTransform
{
    public class RasterKernel
    {
        public Raster Raster { get; private init; }
        public int BorderSize { get; private init; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public RasterKernel(Raster raster, int borderSize)
        {
            if (raster is null) throw new ArgumentNullException(nameof(raster));
            if (borderSize < 0) throw new ArgumentOutOfRangeException(nameof(borderSize), "invalid negative");
            Raster = raster;
            BorderSize = borderSize;
            X = 0;
            Y = 0;
        }

        public IEnumerable<double> Values()
        {
            int startX = Start(X);
            int startY = Start(Y);

            int limitX = LimitX(X);
            int limitY = LimitY(Y);

            for (int x = startX; x < limitX; x++)
            {
                for (int y = startY; y < limitY; y++)
                {
                    double d = Raster.Value(x, y);
                    if (!double.IsNaN(d))
                    {
                        yield return d;
                    }
                }
            }
            int Start(int xy) => Math.Max(xy - BorderSize, 0);
            int LimitX(int x) => Math.Min(x + BorderSize + 1, Raster.Width);
            int LimitY(int y) => Math.Min(y + BorderSize + 1, Raster.Height);
        }

        public bool MoveNext()
        {
            if (++X == Raster.Width)
            {
                X = 0;
                if (++Y == Raster.Height)
                {
                    Y = 0;
                    return false;
                }
                return true;
            }
            return true;
        }
    }
}