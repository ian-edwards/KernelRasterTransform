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
            Raster input = RasterReader.ReadRaster("Data/Data2.csv");
            Raster output = new(1000);
            MeanKernelTransform transform = new(5);

            for (int y = 0; y < 1000; y++)
            {
                for (int x = 0; x < 1000; x++)
                {
                    float? result = transform.Transform(input, x, y);
                    output.SetValue(x, y, result);
                }
            }

            float? f = output.GetValue(500, 500);
        }
    }
}