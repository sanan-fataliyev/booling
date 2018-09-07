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

            for (int row = 0; row < Math.Sqrt(sizeof(ulong)); row++)
                for (int col = 0; col < Math.Sqrt(sizeof(ulong)); col++)
                    Assert.IsFalse(bt[row, col]);

        }

    }
}