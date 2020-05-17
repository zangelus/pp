using NUnit.Framework;
using System.Diagnostics;

namespace Problems.UnitTest
{
    [TestFixture]
    class P003_UT
    {
        public P003_mine_sweeper problem;
        
        [SetUp]
        public void Setup()
        {
            problem = new P003_mine_sweeper();
        }

        //[Test, TestCaseSource("TestCases")]
        public void FillCellWithTheNumberOfBomsAround(int rows, int columns, (int x, int y)[] bombPositions, string result )
        {
            problem.CreateMatrix(bombPositions, rows, columns);

            Assert.AreEqual(result, problem.PrettyPrint());
        }

        [Test, TestCaseSource("Scenarios")]
        public void FillCellsAroundUndiscoveredItems(TestScenario sc)
        {
            problem.CreateMatrix(sc.Poi, sc.Rows, sc.Columns);
            Assert.AreEqual(sc.Result, problem.PrettyPrint());
        }

        public class TestScenario
        {
            public int Rows { get; set; }
            public int Columns { get; set; }
            public (int, int)[] Poi { get; set; }
            public string Result { get; set; }
        }

        private static TestScenario[] Scenarios =
        {
            new TestScenario(){ 
                Rows = 3,
                Columns = 4,
                Poi = new []{(0,0),(0,1)},
                Result = "-1  2  0  0\n" +
                          "-1  2  0  0\n" +
                          " 1  1  0  0\n"
            },

            new TestScenario(){
                Rows = 5,
                Columns = 5,
                Poi = new []{(0,0),(1,1),(2,2),(3,3),(4,4)},
                Result = "-1  2  1  0  0\n" +
                          " 2 -1  2  1  0\n" +
                          " 1  2 -1  2  1\n" +
                          " 0  1  2 -1  2\n" +
                          " 0  0  1  2 -1\n"
            }
        };

        private static object[] TestCases =
        {
            new object[] {
                3, 
                4, 
                new []{(0,0),(0,1)}, 
                "-1  2  0  0\n" +
                "-1  2  0  0\n" +
                " 1  1  0  0\n"
            },
            
            new object[] {
                
            },
        };

    }
}
