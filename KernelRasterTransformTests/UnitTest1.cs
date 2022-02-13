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
            Raster raster = RasterReader.ReadRaster("Data/Data1.csv");
        }
    }
}