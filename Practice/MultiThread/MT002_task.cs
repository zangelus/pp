using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{
    public class MT002_task
    {
        /*Create a Task that returns void*/
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

        /*Create a Task<T> that returns a value*/
        #region Example2
        public static void Example2()
        {
            Task<string> taskReturnData = new Task<string>(() => ReturnRequest());
            taskReturnData.Start();

            DoSomethingElse();

            /* Note .Result wait similarly to .Wait() until task or result is ready*/
            Console.WriteLine(taskReturnData.Result);
        }

        private static void DoSomethingElse()
        {
            Console.WriteLine("Main Tread is doing something else");
        }

        private static string ReturnRequest()
        {
            Console.WriteLine("Processing request");
            Thread.Sleep(2000);
            Task.Delay(2000);
            return "Request returned";
        }
        #endregion


        /* Tasks for IO bound operations */
        #region Exmaple3
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
            Console.WriteLine("Doing something in the main thread");
        }

        private static string GetPost(string url)
        {
            using (var web = new WebClient())
            {
                return web.DownloadString(url);
            }
        }

        #endregion

        #region Task.Delay operation
        public static void Task_Delay_Operation()
        {
            Task runTaskAsync = AsyncTask();
            Console.WriteLine("Do something synchronous in the main thread");
            
            runTaskAsync.Wait();
            Console.WriteLine("Async task just returned");
        }

        private static async Task AsyncTask()
        {
            Task delay = Task.Delay(5000);
            Console.WriteLine("Start async Task");
            await delay;

            //NOTE Return is not needed!!!!
        }

        #endregion


    }
}
