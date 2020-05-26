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

            Task timer = Timer(5);
            timer.Wait();
            Console.WriteLine("Timer finished");
        }

        private static async Task AsyncTask()
        {
            Task delay = Task.Delay(5000);
            Console.WriteLine("Start async Task");
            await delay;

            //NOTE Return is not needed!!!!
        }

        private static async Task Timer(int sec)
        {
            for (int i = 0; i < sec; i++)
            {
                Task d = Task.Delay(1000);
                await d;
                Console.WriteLine($"{i+1} sec elapsed");
            }
           
        }

        #endregion

        #region Task_Delay_With_Returned_Value_Operation

        public static void Task_Delay_return_data()
        {
            Task<byte[]> async_op1 = AsyncDownloadUsingTaskDelay();
            foreach (var el in async_op1.Result)
            {
                Console.WriteLine($"data: {el}");
            }
        }

        public static void Task_for_loop_return_data()
        {
            Task<byte[]> async_op2 = AsyncDownload2(new byte[3] { 12,13,14});

            Console.WriteLine("main thread is doing something");

            async_op2.Wait();
            Console.Write($"data: ");
            foreach (var el in async_op2.Result)
            {
                Console.Write($"{el}, ");
            }
        }

        private static async Task<byte[]> AsyncDownload2(byte[] sequence)
        {
            Task<byte[]> t1 = Task.Factory.StartNew(() => {

                for (int i = 1; i < 1000; i++)
                {
                    for (int i2 = 1; i2 < 1000000; i2++)
                    {      
                    }

                    if((i % 100) == 0)
                    {
                        Console.WriteLine($"Iteration {i}/10");
                    }
                    
                }
                Console.WriteLine("count 100M finished");

                byte[] result = new byte[sequence.Length];
                sequence.CopyTo(result, 0);

                for (int i = 0; i < result.Length; i++)
                {
                    result[i]++;
                }

                return result;
            });

            return await t1;
        }

        private static async Task<byte[]> AsyncDownloadUsingTaskDelay()
        {
            Task delay = Task.Delay(2000);
            /*normally the await unpacks the TResult from a Task<TResult>*/
            await delay;
            
            /*In this specific example, we still need to return data*/
            return new byte[7] { 7,6,5,4,3,2,1};
        }
        #endregion

        #region Task continuation
        public static void TaskContinuation()
        {
            //Task<string> antecedent = Task.Run(() => DateTime.Now.ToString());

            
            Task<string> antecedent = Task.Run(() =>
            {
                Console.WriteLine(DateTime.Now.ToString());
                Console.WriteLine("Add 3 sec delay and recalculate");
                Task.Delay(3000).Wait();
                return DateTime.Now.ToString(); 
            });
            Task<string> continuation = antecedent.ContinueWith(r => 
            {
                return "Today is " + r.Result;
            });

            Console.WriteLine(continuation.Result);
        }

        #endregion


    }
}
