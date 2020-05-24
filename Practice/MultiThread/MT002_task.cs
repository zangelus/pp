using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MultiThread
{
    public class MT002_task
    {
        #region Example1
        public static void Example1()
        {
            Task taskReturnVoid = new Task(PrintHello);
            taskReturnVoid.Start();
        }
        private static void PrintHello()
        {
            Console.WriteLine("Hello World");
        }
        #endregion

        #region Example2
        public static void Example2()
        {
            Task<string> taskReturnData = new Task<string>(() => ReturnHello());
            taskReturnData.Start();

            /* Note .Result wait similarly to .Wait() until task or result is ready*/
            Console.WriteLine(taskReturnData.Result);
        }
        private static string ReturnHello()
        {
            Task.Delay(2000);
            return "Return Hello";
        }
        #endregion


        /* Tasks for IO bound operations */
        public static void Example3()
        {
            Task<string> myTask = Task.Factory.StartNew<string>(() => GetPost("https://jsonplaceholder.typicode.com/posts"));

            /* Do something else in betwee*/
            DoSomethingElseExample3();

            try
            {
                Console.WriteLine(myTask.Result); /* the main thread will wait 
                                                     until .Result is fullfilled */
            }
            catch(AggregateException e) /* This type brings the execption to
                                           the main thread/execution */
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void DoSomethingElseExample3()
        {
            //throw new NotImplementedException();
        }

        private static string GetPost(string url)
        {
            using (var web = new WebClient())
            {
                return web.DownloadString(url);
            }
        }



    }
}
