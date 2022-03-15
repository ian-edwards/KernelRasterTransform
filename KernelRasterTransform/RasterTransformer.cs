namespace KernelRasterTransform
{
    public class RasterTransformer
    {
        public static Raster TransformRaster(Raster raster, int kernelBorderSize, IRasterTransform transform)
        {
            var outputData = new float[raster.EdgeSize * raster.EdgeSize];
            var kernel = new RasterKernel(raster, kernelBorderSize);
            long i = 0;
            do
            {
                var inputValues = kernel.Values();
                float outputValue = transform.Transform(inputValues);
                outputData[i++] = outputValue;
            }
            while (kernel.MoveNext());
            return new Raster(raster.EdgeSize, outputData);
        }
    }
}
