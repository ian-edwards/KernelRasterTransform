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
            Raster raster1 = RasterReader.ReadRaster("Data/Data1.csv");
            Raster raster2 = RasterReader.ReadRaster("Data/Data2.csv");
        }
    }
}