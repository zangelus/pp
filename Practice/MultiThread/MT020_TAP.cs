using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{

    /* ************************************************************
     * Notes:
     * 1.- async: 
     * 1.1 - Can only be used in method that return void/Task/Task<T>
     * 2.- await: 
     * 2.1 - give up control to the caller thread until that operation
     *       completes. 
     * 2.2 - No need to to invoke Start() on the Task/Task<T>
     * ************************************************************/

    public class MT020_TAP
    {
        readonly static string _url1 = "https://go.microsoft.com/fwlink/p/?linkid=2120735";
        readonly static string _url2 = "http://deelay.me/5000/https://www.google.com/";

        public static void Main(int option)
        {
            switch (option)
            {
                case 1:
                    Download_Blocking_Main_Thread();
                    break;
                case 2:
                    Download_Using_Task();
                    break;
                case 3:
                    Download_with_async_await();
                    break;
                default:
                    break;
            }

            Console.WriteLine("Waiting for download operation to finish");
            Console.ReadLine();
        }

        public static void Example1()
        {
            Download_with_async_await();
            Console.WriteLine("Doing something else");
        }


        /* The compiler uses the async / await keyworks to
         * programatically split the method in two, one that
         * waits for the operation to resume and second that
         * continue execution on the main thread out of the 
         * method. It makes very convenit to see it in written
         * code/
        */
        private async static Download_with_async_await()
        {
            //var downloader = new WebClient();
            //byte[] data = await downloader.DownloadDataTaskAsync(_url1);
            //Console.WriteLine("Length is: " + data.Length);

            byte[] rawdata = await SimulateDownload();
            Console.WriteLine("Length is: " + rawdata.Length);
        }

        private static Task<byte[]> SimulateDownload()
        {
            return Task.Factory.StartNew<byte[]>(()=> 
            {
                Thread.Sleep(4000);
                return new byte[15];
            });

            //return new Task<byte[]>(() =>
            //{
            //    Task.Delay(4000);
            //    return new byte[] { 1, 2, 3, 4, 5 };
            //});
        }

        /*
         * Traditional download that blocks the thread
        */
        private static void Download_Blocking_Main_Thread()
        {
            var downloader = new WebClient();
            byte[] data = downloader.DownloadData(_url1);
            Console.WriteLine("Length is: " + data.Length);
        }

        private static void Download_Using_Task()
        {
            var downloader = new WebClient();
            /*
             * DownloadDataTaskAsync returns Task<byte[]> which is 
             * the data wrap in the Task and overhead like result,
             * execptionm information
            */
            Task<byte[]> rawdata = downloader.DownloadDataTaskAsync(_url1);

            /* from here we will need to handle ourself the Task to
             * get the raw date.
             */
            rawdata.Start();

            /* Give control to the main thread
             * DoSomeOtherStuff();
            */
            byte[] data = rawdata.Result;
            Console.WriteLine("Length is: " + data.Length);
        }

        public static void Example2()
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                tokenSource.Cancel();
            });
            DownloadAsync(new Uri("https://jsonplaceholder.typicode.com/posts"), token).Wait();
        }

        public static async Task DownloadAsync(Uri uri,
            CancellationToken token)
        {
            while (true)
            {
                token.ThrowIfCancellationRequested();
                try
                {
                    //HttpResponseMessage result = await GetAsync(uri);//3 secn
                    int result = await GetIntAsync(3);
                    Console.WriteLine("Result is {0}", result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            HttpClient client = new HttpClient();
            var result = client.GetAsync(uri);
            return result;
        }

        private static Task<int> GetIntAsync(int seed)
        {
            Task<int> a = new Task<int>(() => { return 1; });
            return new Task<int>(()=> { return seed + 1; });
        }

    }
}
