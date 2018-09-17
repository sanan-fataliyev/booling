using System;
using System.Security.Cryptography.X509Certificates;
using Booling;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InitializeAllCellsWithFalseInDefaultConstructorTest()
        {
            BoolTable bt = new BoolTable();

            for (int row = 0; row < 8; row++)
                for (int col = 0; col < 8; col++)
                    Assert.IsFalse(bt[row, col], $"value in [{row},{col}] is calculated to true but expected false");

        }

        [Test]
        public void FirstCellTest()
        {
            BoolTable bt = new BoolTable();

            bt[0, 0] = true;
            Assert.IsTrue(bt[0,0]);

            bt[0, 0] = false;
            Assert.IsFalse(bt[0,0]);
        }

        [Test]
        public void LastCellTest()
        {
            BoolTable bt = new BoolTable();

            bt[7, 7] = true;
            Assert.IsTrue(bt[7, 7]);

            bt[7, 7] = false;
            Assert.IsFalse(bt[7, 7]);
        }

        [Test]
        public void CastFromTwoDimArrayTest()
        {
            bool[,] array =
            {
                {true, false, false, true, true, true, false, false},
                {false, false, true, false, false, true, true, false},
                {true, false, false, false, true, true, true, false},
                {true, false, true, true, false, true, false, false},
                {false, false, true, true, false, true, true, true},
                {false, false, false, false, false, true, false, true},
                {true, true, true, true, false, false, true, false},
                {true, false, false, true, true, false, false, false}
            };

            BoolTable b = (BoolTable)array;

            for (int i = array.GetLowerBound(0); i <= array.GetUpperBound(0); i++)
                for (int j = array.GetLowerBound(1); j <= array.GetUpperBound(1); j++)
                    Assert.IsTrue(b[i, j] == array[i, j]);
        }

        [Test]
        public void InvertTest()
        {
            bool[,] array =
            {
                {true, false, false, true, true, true, false, false},
                {false, false, true, false, false, true, true, false},
                {true, false, false, false, true, true, true, false},
                {true, false, true, true, false, true, false, false},
                {false, false, true, true, false, true, true, true},
                {false, false, false, false, false, true, false, true},
                {true, true, true, true, false, false, true, false},
                {true, false, false, true, true, false, false, false}
            };

            BoolTable b = (BoolTable)array;

            b.Invert();

            for (int i = array.GetLowerBound(0); i <= array.GetUpperBound(0); i++)
                for (int j = array.GetLowerBound(1); j <= array.GetUpperBound(1); j++)
                    Assert.IsTrue(b[i, j] == !array[i, j]);
        }


    }
}