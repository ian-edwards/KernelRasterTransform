namespace KernelRasterTransform
{
    public interface IRasterKernel
    {
        IRaster Raster { get; }

        int X { get; }

        int Y { get; }

        int BorderX { get; }

        int BorderY { get; }
    }
}
