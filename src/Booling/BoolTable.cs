using System;
using System.Collections.Generic;
using System.Text;

namespace Booling
{
    public struct BoolTable : IBoolTable
    {
        // ulong has 64 bits and we use it as 8x8 booleans table
        private ulong _bits;

        private const int __RowsCount = 8;
        private const int __BitsPerRow = 8;


        private void ValidateCellAddress(int row, int col)
        {
            if(row < 0 || row >= __RowsCount || col < 0 || col >= __BitsPerRow)
                throw new IndexOutOfRangeException();
        }


        public int Rank => 2;
        

        public bool this[int row, int col]
        {
            get
            {
                ValidateCellAddress(row, col);
                return (this._bits & (1UL << (row * __BitsPerRow + col))) > 0UL;
            }

            set
            {
                ValidateCellAddress(row, col);

                if (value)
                {
                    this._bits |= 1UL << (row * __BitsPerRow + col);
                }
                else
                {
                    this._bits &= ~(1UL << (row * __BitsPerRow + col));
                }
            }
        }

        public override string ToString()
        {
            return Convert.ToString((long) this._bits, 2).PadLeft(64, '0');
        }
    }
}
