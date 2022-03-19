namespace KernelRasterTransform
{
    public interface IRasterTransform
    {
        double Transform(IEnumerable<double> values);
    }
}
