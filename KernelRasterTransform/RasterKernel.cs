namespace KernelRasterTransform
{
    public record RasterKernel(Raster Raster, int BorderSize, int CenterX, int CenterY, int StartX, int StartY, int LimitX, int LimitY)
    {
        public RasterKernel Move(int x, int y) => new(Raster, BorderSize, CenterX: x, CenterY: y,
            StartX: Math.Max(x - BorderSize, 0),
            StartY: Math.Max(y - BorderSize, 0),
            LimitX: Math.Min(x + BorderSize + 1, Raster.Width),
            LimitY: Math.Min(y + BorderSize + 1, Raster.Height));
    }
}
