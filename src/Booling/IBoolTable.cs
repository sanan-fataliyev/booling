using System;
using System.Collections.Generic;
using System.Text;

namespace Booling
{
    interface IBoolTable /*IEnumerable<bool>, IEnumerable<bool[]>*/
    {
        bool this[int row, int col] { get; set; }
    }
}
