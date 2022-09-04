namespace KernelRasterTransform
{
    internal class InternalRasterKernel : IRasterKernel
    {
        public IRaster Raster { get; private init; }

        public int X { get; private init; }

        public int Y { get; private init; }

        public int BorderX { get; private init; }

        public int BorderY { get; private init; }


        internal InternalRasterKernel(IRaster raster, int borderX, int borderY, int x, int y)
        {
            Raster = raster;
            X = x;
            Y = y;
            BorderX = borderX;
            BorderY = borderY;
        }
    }
}