using NUnit.Framework;
using Problems;

namespace Problems.UnitTest
{
    [TestFixture]
    public class P001_UT
    {
        P001_GetFirstNonRepeatingCharacter problem;
        [SetUp]
        public void Setup()
        {
            problem = new P001_GetFirstNonRepeatingCharacter();
        }

        [Test, TestCaseSource("TestCases")]
        public void TestNonRepeatingCharactersAreReturned(string word, char? expected)
        {
             Assert.AreEqual(expected, problem.NonRepeatingCharacter(word), "The expected character isnt equal");
        }

        static object[] TestCases =
        {
            new object[] { "aabcb", 'c'},
            new object[] { "xxyz", 'y'},
            new object[] { "aabb", null}
        };
    }
}