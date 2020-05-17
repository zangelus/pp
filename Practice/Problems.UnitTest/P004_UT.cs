using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Problems.UnitTest
{
    [TestFixture]
    class P004_UT
    {
        public P004_mine_sweeper_expand problem;
        
        [SetUp]
        public void Setup()
        {
            problem = new P004_mine_sweeper_expand();
        }

        [Test, TestCaseSource("TestCases")] 
        public void TestBreatFirstSearch(int[,] field, int row, int col, int[,] result )
        {
            Assert.AreEqual(result, problem.Breath_first_search(field, (row, col)));
        }

        [Test, TestCaseSource("TestCases")]
        public void TestDepthFirstSearch(int[,] field, int row, int col, int[,] expected)
        {
            int[,] result = problem.Depth_first_search(field, (row, col));
            Assert.AreEqual(expected, result);
        }

        private static int[,] BaseMatrix1 = new int[,]{ {0, 0, 0, 0, 0},
                                                        {0, 1 ,1, 1, 0},
                                                        {0, 1,-1, 1, 0}};

        private static int[,] BaseMatrix2 = new int[,]{ {-1, 1, 0, 0},
                                                        { 1, 1, 0, 0},
                                                        { 0, 0, 1, 1},
                                                        { 0, 0, 1,-1}};

        private static object[] TestCases =
        {
            new object[] { BaseMatrix1,
                           0,0,
                           new int[,]{
                                        {-2,-2,-2,-2,-2},
                                        {-2, 1 ,1, 1,-2},
                                        {-2, 1,-1, 1,-2}
                                     }
             },

            new object[] { BaseMatrix1,
                           1,1,
                           new int[,]{
                                        { 0, 0, 0, 0, 0},
                                        { 0, 1 ,1, 1, 0},
                                        { 0, 1,-1, 1, 0}
                            }
            },

            new object[] { BaseMatrix2,
                           2,0,
                           new int[,]{ {-1, 1,-2,-2},
                                       { 1, 1,-2,-2},
                                       {-2,-2, 1, 1},
                                       {-2,-2, 1,-1}
                           }        
            }
        };
    }
}
