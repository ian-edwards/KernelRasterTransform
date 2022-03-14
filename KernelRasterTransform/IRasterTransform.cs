using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernelRasterTransform
{
    internal interface IRasterTransform
    {
        float Transform(IEnumerable<float> values);
    }
}
