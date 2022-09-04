using System.Diagnostics;

namespace KernelRasterTransform
{
    public class RasterTransformer
    {
        public static Raster TransformRasterKernel(RasterKernel kernel, IRasterTransform transform)
        {
            Raster raster = kernel.Raster;
            var output = new double[raster.Width * raster.Height];
            for (int x = 0; x < raster.Width; x++)
            {
                for (int y = 0; y < raster.Height; y++)
                {
                    output[x * raster.Width + y] = transform.Transform(kernel.Move(x, y));
                }
            }
            return new Raster(output, raster.Width, raster.Height);
        }
    }
}