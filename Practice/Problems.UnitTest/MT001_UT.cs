using NUnit.Framework;
using MultiThread;
using System;
using System.Threading;

namespace Problems.UnitTest
{
    [TestFixture]
    class MT001_UT
    {
        [Test]
        public void Test1()
        {
            MT001_threads.TwoThreadsRunning();
        }

        [Test]
        public void Test2()
        {
            MT001_threads.ThreadSyncWithJoin();
        }

        [Test]
        public void Test3()
        {
            MT001_threads.PassingArgument();
        }


        [Test]
        public void Test4()
        {
            MT001_threads.Test4();
        }

        [Test]
        public void Test5()
        {
            MT001_threads.Test5();
        }


        [Test]
        public void Test6()
        {
            MT001_threads.Test6();
        }

        [Test]
        public void Test7()
        {
            MT001_threads.Test7();
        }

        [Test]
        public void TestShouldNotBeHEre()
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.console.writeline?view=netcore-3.1
            int a = 1;
            float b = 2.1f;
            string c = "tres";
            Console.WriteLine($"a={a:C}, b={b:F}, c={c:G}");

        }
    }
}
