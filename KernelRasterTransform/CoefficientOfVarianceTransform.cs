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

        public double Transform(IEnumerable<double> values)
        {
            double[] valuesArray = values.ToArray();
            if (valuesArray.Length > _threshold)
            {
                double avg = valuesArray.Average();
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                double variance = (sum) / (values.Count() - 1);
                return variance / avg;
            }
            else
            {
                return double.NaN;
            }
        }
    }
}