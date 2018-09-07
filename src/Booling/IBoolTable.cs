using System;
using System.Collections.Generic;
using System.Text;

namespace Booling
{
    interface IBoolTable /*IEnumerable<bool>, IEnumerable<bool[]>*/
    {
        bool this[int m, int n] { get; set; }
    }
}
