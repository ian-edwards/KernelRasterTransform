using KernelRasterTransform;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace KernelRasterTransformTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Stopwatch sw = Stopwatch.StartNew();
            Raster raster = RasterReader.ReadRaster("Data/Data2.csv");
            RasterKernel kernel = raster.CreateKernel(borderSize: 2);
            CoefficientOfVarianceTransform transform = new(threshold: 2);
            Raster output = RasterTransformer.TransformRasterKernel(kernel, transform);
            Debug.WriteLine(sw.Elapsed);
        }
    }
}