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
            IRaster raster = RasterReader.ReadRaster("Data/Data2.csv");
            IRasterKernel kernel = raster.CreateKernel(border: 2);
            CoefficientOfVarianceTransform transform = new(threshold: 2);
            IRaster output = RasterTransformer.TransformRasterKernel(kernel, transform);
        }
    }
}