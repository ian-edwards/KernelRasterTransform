using KernelRasterTransform;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KernelRasterTransformTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Raster inputRaster = RasterReader.ReadRaster("Data/Data2.csv");
            RasterKernel kernel = inputRaster.CreateKernel(borderSize: 1);
            kernel.MoveNext();
            var et = new ExampleSumTransform();
            float f = et.Transform(kernel.Values());
        }
    }
}