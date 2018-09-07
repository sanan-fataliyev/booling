using System;
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


    }
}