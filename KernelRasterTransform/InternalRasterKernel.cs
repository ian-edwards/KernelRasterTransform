namespace KernelRasterTransform
{
    internal class InternalRasterKernel : IRasterKernel
    {
        public IRaster Raster { get; private init; }

        public int BorderSize { get; private init; }

        public int CenterX { get; private init; }

        public int CenterY { get; private init; }

        internal InternalRasterKernel(IRaster raster, int borderSize, int centerX, int centerY)
        {
            Raster = raster;
            BorderSize = borderSize;
            CenterX = centerX;
            CenterY = centerY;
        }
    }
}