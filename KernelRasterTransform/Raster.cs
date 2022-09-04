namespace KernelRasterTransform
{
    public static class Raster
    {
        public static IRasterKernel CreateKernel(this IRaster raster, int border) => CreateKernel(raster, borderX: border, borderY: border, x: 0, y: 0);

        public static IRasterKernel CreateKernel(this IRaster raster, int borderX, int borderY) => CreateKernel(raster, borderX, borderY, x: 0, y: 0);

        public static IRasterKernel CreateKernel(this IRaster raster, int border, int x, int y) => CreateKernel(raster, borderX: border, borderY: border, x, y);

        public static IRasterKernel CreateKernel(this IRaster raster, int borderX, int borderY, int x, int y) => new InternalRasterKernel(raster, borderX, borderY, x, y);
    }
}
