using ExtensionMethods;
using NUnit.Framework;
using System;


namespace Problems.UnitTest
{
    [TestFixture]
    class ET0001_UT
    {
        [Test]
        public void TestIterationPattern()
        {
            string test1 = "The number of characters is ";
            Assert.AreEqual(28, test1.CountCharacteres());
        }

        [Test]
        public void GetRowFromMatrix()
        {
            int[,] matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[] expected_r0 = new int[] { 1, 2, 3 };
            int[] expected_r1 = new int[] { 4, 5, 6 };
            int[] expected_r2 = new int[] { 7, 8, 9 };
             
            Assert.AreEqual(expected_r0, matrix.GetRow<int>(0));
            Assert.AreEqual(expected_r1, matrix.GetRow<int>(1));
            Assert.AreEqual(expected_r2, matrix.GetRow<int>(2));
            Assert.AreNotEqual(expected_r0, matrix.GetRow<int>(1));
        }

        [Test]
        public void GetColumnFromMatrix()
        {
            int[,] matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[] expected_col0 = new int[]{ 1, 4, 7};
            int[] expected_col1 = new int[]{ 2, 5, 8};
            int[] expected_col2 = new int[]{ 3, 6, 9};

            Assert.AreEqual(expected_col0, matrix.GetColumn<int>(0));
            Assert.AreEqual(expected_col1, matrix.GetColumn<int>(1));
            Assert.AreEqual(expected_col2, matrix.GetColumn<int>(2));
        }
    }
}
