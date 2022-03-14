using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernelRasterTransform
{
    public class RasterKernel
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        readonly Raster _raster;
        readonly int _borderSize;

        internal RasterKernel(Raster raster, int borderSize)
        {
            if (raster is null) throw new ArgumentNullException(nameof(raster));
            if (borderSize < 0) throw new ArgumentOutOfRangeException(nameof(borderSize), "invalid negative");
            _raster = raster;
            _borderSize = borderSize;
            X = 0;
            Y = 0;
        }

        public IEnumerable<float> Values()
        {
            int startX = Start(X);
            int startY = Start(Y);

            int limitX = Limit(X);
            int limitY = Limit(Y);

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
            if(++X == _raster.EdgeSize)
            {
                X = 0;
                if (++Y == _raster.EdgeSize)
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
