namespace KernelRasterTransform
{
    public interface IRasterKernel
    {
        IRaster Raster { get; }

        int BorderSize { get; }

        int CenterX { get; }

        int CenterY { get; }
    }
}
