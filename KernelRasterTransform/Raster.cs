namespace KernelRasterTransform
{
    public record Raster(double[] Data, int Width, int Height)
    {
        public RasterKernel CreateKernel(int borderSize, int centerX, int centerY) => new(this, borderSize, centerX, centerY,
            StartX: Math.Max(centerX - borderSize, 0),
            StartY: Math.Max(centerY - borderSize, 0),
            LimitX: Math.Min(centerX + borderSize + 1, Width),
            LimitY: Math.Min(centerY + borderSize + 1, Height));

        public RasterKernel CreateKernel(int borderSize) => CreateKernel(borderSize, centerX: 0, centerY: 0);
    }
}
