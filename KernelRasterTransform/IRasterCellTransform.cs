using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernelRasterTransform
{
    public interface IRasterCellTransform
    {
        float Transform(int x, int y, Func<int, int, float> cell);
    }
}
