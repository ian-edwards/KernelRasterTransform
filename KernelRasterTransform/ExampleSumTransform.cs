using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernelRasterTransform
{
    public class ExampleSumTransform : IRasterTransform
    {
        public float Transform(IEnumerable<float> values) => values.Sum();
    }
}
