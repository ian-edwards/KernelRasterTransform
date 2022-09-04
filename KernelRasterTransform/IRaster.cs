namespace KernelRasterTransform
{
    public interface IRaster
    {
        int Width { get; }

        int Height { get; }

        double Value(int x, int y);
    }
}
