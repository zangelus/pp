using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Problems.UnitTest
{
    class P003_UT
    {
        public P003_mine_sweeper problem;
        
        [SetUp]
        public void Setup()
        {
            problem = new P003_mine_sweeper();
        }

        [Test, TestCaseSource("TestCases")]
        public void FillCellWithTheNumberOfBomsAround(int rows, int columns, (int x, int y)[] bombPositions, string result )
        {
            problem.CreateMatrix(bombPositions, rows, columns);

            Assert.AreEqual(result, problem.PrettyPrint());
        }

        private static object[] TestCases =
        {
            new object[] {3, 4, new []{(0,0),(0,1)}, "-1  2  0  0\n" +
                                                     "-1  2  0  0\n" +
                                                     " 1  1  0  0\n"},
            
            new object[] {5, 5, new []{(0,0),(1,1),(2,2),(3,3),(4,4)},  "-1  2  1  0  0\n" +
                                                                        " 2 -1  2  1  0\n" +
                                                                        " 1  2 -1  2  1\n" +
                                                                        " 0  1  2 -1  2\n" +
                                                                        " 0  0  1  2 -1\n"},
        };

    }
}
