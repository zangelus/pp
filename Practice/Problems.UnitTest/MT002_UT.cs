using NUnit.Framework;
using MultiThread;
using System;
using System.Threading;

namespace Problems.UnitTest
{
    [TestFixture]
    class MT002_UT
    {
        [Test]
        public void Task_return_void()
        {
            MT002_task.Example1();
        }

        [Test]
        public void Task_return_string()
        {
            MT002_task.Example2();
        }
    }
}
