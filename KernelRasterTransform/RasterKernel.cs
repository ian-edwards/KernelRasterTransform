namespace KernelRasterTransform
{
    public static class RasterKernel
    {
        public static IEnumerable<double> EnumerateValues(this IRasterKernel kernel)
        {
            int startX = Math.Max(kernel.X - kernel.BorderX, 0);
            int startY = Math.Max(kernel.Y - kernel.BorderY, 0);
            int limitX = Math.Min(kernel.X + kernel.BorderX + 1, kernel.Raster.Width);
            int limitY = Math.Min(kernel.Y + kernel.BorderY + 1, kernel.Raster.Height);
            for (int x = startX; x < limitX; x++)
            {
                for (int y = startY; y < limitY; y++)
                {
                    double d = kernel.Raster.Value(x, y);
                    if (!double.IsNaN(d))
                    {
                        yield return d;
                    }
                }
            }
        }
    }
}
