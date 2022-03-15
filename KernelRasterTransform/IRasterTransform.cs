namespace KernelRasterTransform
{
    public interface IRasterTransform
    {
        float Transform(IEnumerable<float> values);
    }
}
