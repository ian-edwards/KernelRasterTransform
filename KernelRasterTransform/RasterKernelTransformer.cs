namespace KernelRasterTransform
{
    public class RasterKernelTransformer
    {
        public static Raster TransformRasterKernel(RasterKernel kernel, IRasterTransform transform)
        {
            Raster raster = kernel.Raster;
            var outputData = new double[raster.Width * raster.Height];
            long i = 0;
            do
            {
                IEnumerable<double> inputValues = kernel.Values();
                double outputValue = transform.Transform(inputValues);
                outputData[i++] = outputValue;
            }
            while (kernel.MoveNext());
            return new Raster(raster.Width, raster.Height, outputData);
        }
    }
}