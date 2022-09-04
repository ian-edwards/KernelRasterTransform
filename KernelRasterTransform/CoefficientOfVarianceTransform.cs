namespace KernelRasterTransform
{
    public class CoefficientOfVarianceTransform : IRasterTransform
    {
        readonly int _threshold;

        public CoefficientOfVarianceTransform(int threshold)
        {
            if (threshold <= 0) throw new ArgumentException("invalid zero or negative", nameof(threshold));
            _threshold = threshold;
        }

        public double Transform(RasterKernel kernel)
        {
            int width = kernel.Raster.Width;
            int height = kernel.Raster.Height;
            double[] raster = kernel.Raster.Data;
            double t = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    t += raster[x * width + y];
                }
            }
            double sum = 0;
            int count = 0;
            for (int x = kernel.StartX; x < kernel.LimitX; x++)
            {
                for (int y = kernel.StartY; y < kernel.LimitY; y++)
                {
                    double d = raster[x * width + y];
                    if (!double.IsNaN(d))
                    {
                        sum += d;
                        count++;
                    }
                }
            }
            if (count > _threshold)
            {
                double mean = sum / count;
                double sum2 = 0;
                for (int x = kernel.StartX; x < kernel.LimitX; x++)
                {
                    for (int y = kernel.StartY; y < kernel.LimitY; y++)
                    {
                        double d = raster[x * width + y];
                        if (!double.IsNaN(d))
                        {
                            sum2 += Math.Pow(d - mean, 2);
                        }
                    }
                }
                double variance = sum2 / (count - 1);
                return t + variance / mean;
            }
            else
            {
                return double.NaN;
            }
        }
    }
}