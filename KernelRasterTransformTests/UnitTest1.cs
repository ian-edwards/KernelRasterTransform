using KernelRasterTransform;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KernelRasterTransformTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Raster input = RasterReader.ReadRaster("Data/Data3.csv");
            RasterKernel kernel = new(input, borderSize: 2);
            CoefficientOfVarianceTransform transform = new(threshold: 2);
            Raster output = RasterKernelTransformer.TransformRasterKernel(kernel, transform);
        }
    }
}