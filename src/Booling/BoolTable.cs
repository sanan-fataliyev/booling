using System;
using System.Collections.Generic;
using System.Text;

namespace Booling
{
    public struct BoolTable : IBoolTable
    {
        private ulong _bits;

        public bool this[int m, int n]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}
