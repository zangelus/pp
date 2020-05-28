using ExtensionMethods;
using NUnit.Framework;
using System;
using System.Linq;

namespace Problems.UnitTest
{
    [TestFixture]
    class General_UT
    {
        [Test]
        public void ModCalculator()
        {
            foreach (var num in Enumerable.Range(1,100))
            {

                Console.WriteLine($"{num} mod: {(num % 10)}");
            }            
        }

    }
}
