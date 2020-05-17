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

    }
}
