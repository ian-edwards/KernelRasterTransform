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
            Raster inputRaster = RasterReader.ReadRaster("Data/Data2.csv");
            var sumTransform = new ExampleSumTransform();
            Raster outputRaster = RasterTransformer.TransformRaster(inputRaster, kernelBorderSize: 1, sumTransform);
        }
    }
}