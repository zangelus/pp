using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Problems.UnitTest
{
    class P002_UT
    {
        public P002_one_away_string problem;
        
        [SetUp]
        public void Setup()
        {
            problem = new P002_one_away_string();
        }

        [Test, TestCaseSource("TestCases")]
        public void UnitTestProblem(string s1, string s2, bool expected_result)
        {
            Assert.AreEqual(expected_result, problem.AreOneAway(s1, s2));
        }

        private static object[] TestCases =
        {
            new object[] { "abcde", "abfde", true },
            new object[] { "abcde", "abde", true },
            new object[] { "xyz", "xyaz", true },
            new object[] { "xyz", "xyazb", false },
            new object[] { "aabbcc", "abc", false }
        };


    }
}
