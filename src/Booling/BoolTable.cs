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

        public void Invert()
        {
            this._bits = ~this._bits;
        }

        public static explicit operator BoolTable(bool[,] array)
        {
            if(array == null)
                throw new ArgumentNullException(nameof(array));
            if (array.Rank != 2)
                throw new InvalidCastException("array is not two-dimentional");;

            if (array.GetLength(0) != __RowsCount || array.GetLength(1) != __BitsPerRow)
                throw new InvalidCastException($"array size must be {__RowsCount}x{__BitsPerRow}");

            BoolTable b = new BoolTable();

            int pos = 0;

            for (int i = array.GetLowerBound(0); i <= array.GetUpperBound(0); i++)
                for (int j = array.GetLowerBound(1); j <= array.GetUpperBound(1); j++)
                    b[pos / __RowsCount, pos++ % __BitsPerRow] = array[i, j];
            
            return b;
        }


        public override string ToString()
        {
            return Convert.ToString((long) this._bits, 2).PadLeft(64, '0');
        }
    }
}
