namespace KernelRasterTransform
{
    public class RasterKernel
    {
        readonly Raster _raster;
        readonly int _borderSize;
        int _x;
        int _y;

        internal RasterKernel(Raster raster, int borderSize)
        {
            if (raster is null) throw new ArgumentNullException(nameof(raster));
            if (borderSize < 0) throw new ArgumentOutOfRangeException(nameof(borderSize), "invalid negative");
            _raster = raster;
            _borderSize = borderSize;
            _x = 0;
            _y = 0;
        }

        public IEnumerable<float> Values()
        {
            int startX = Start(_x);
            int startY = Start(_y);

            int limitX = Limit(_x);
            int limitY = Limit(_y);

            for (int x = startX; x < limitX; x++)
            {
                for (int y = startY; y < limitY; y++)
                {
                    float f = _raster.Value(x, y);
                    if (!float.IsNaN(f))
                    {
                        yield return f;
                    }
                }
            }
            int Start(int xy) => Math.Max(xy - _borderSize, 0);
            int Limit(int xy) => Math.Min(xy + _borderSize + 1, _raster.EdgeSize);
        }

        public bool MoveNext()
        {
            if(++_x == _raster.EdgeSize)
            {
                _x = 0;
                if (++_y == _raster.EdgeSize)
                {
                    _y = 0;
                    return false;
                }
                return true;
            }
            return true;
        }
    }
}
