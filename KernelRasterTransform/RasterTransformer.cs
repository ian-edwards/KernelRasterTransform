namespace KernelRasterTransform
{
    public class RasterTransformer
    {
        public static IRaster TransformRasterKernel(IRasterKernel kernel, IRasterTransform transform)
        {
            int borderX = kernel.BorderX, borderY = kernel.BorderY;
            IRaster raster = kernel.Raster;
            int rasterWidth = raster.Width, rasterHeight = raster.Height;
            var output = new double[rasterWidth * rasterHeight];
            for (int x = 0; x < rasterWidth; x++)
            {
                for (int y = 0; y < rasterHeight; y++)
                {
                    output[x * rasterWidth + y] = transform.Transform(new InternalRasterKernel(raster, borderX, borderY, x, y));
                }
            }
            return new InternalRaster(output, rasterWidth, rasterHeight);
        }
    }
}