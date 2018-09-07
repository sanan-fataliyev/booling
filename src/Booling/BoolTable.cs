using System;
using System.Collections.Generic;
using System.Text;

namespace Booling
{
    public struct BoolTable : IBoolTable
    {
        private ulong _bits;


        public int Rank => 2;

        public bool this[int m, int n]
        {
            get { return (_bits & (1UL << (m * 8 + n - 1))) == 1UL; }
            set { throw new NotImplementedException(); }
        }
    }
}
