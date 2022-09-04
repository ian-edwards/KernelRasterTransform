namespace KernelRasterTransform
{
    public class CoefficientOfVarianceTransform : IRasterTransform
    {
        readonly int _threshold;

        public CoefficientOfVarianceTransform(int threshold)
        {
            if (threshold < 0) throw new ArgumentException("invalid negative", nameof(threshold));
            _threshold = threshold;
        }

        public double Transform(IRasterKernel kernel)
        {
            // test
            double d = 0;
            for(int x = 0; x < kernel.Raster.Width; x++)
            {
                for (int y = 0; y < kernel.Raster.Height; y++)
                {
                    d += kernel.Raster.Value(x, y);
                }
            }
            // end test
            double[] values = kernel.EnumerateValues().ToArray();
            return values.Length > _threshold
                ? d + CoefficientOfVariance(values) // d test
                : double.NaN;
        }

        static double CoefficientOfVariance(double[] values)
        {
            double mean = values.Average();
            double sum = values.Sum(d => Math.Pow(d - mean, 2));
            double variance = sum / (values.Length - 1);
            return variance / mean;
        }
    }
}