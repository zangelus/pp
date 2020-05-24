using System;
using System.Net.Http.Headers;
using System.Threading;

namespace MultiThread
{
    public class MT001_threads
    {
        /* ******************************************
        * Example 1 - The idea is to demonstrate how 
        * a Thread can be create from the main Thread
        * 
        * *****************************************/
        public static void TwoThreadsRunning()
        {
            Thread t1 = new Thread(SayHello);
            t1.Start();

            Console.WriteLine("World");
        }

        /* ******************************************
        * Example 2 - The idea is to demonstrate how 
        * a Thread can be syncronized using the blocking 
        * statement Join
        * *****************************************/
        public static void ThreadSyncWithJoin()
        {
            Thread t1 = new Thread(SayHello);
            t1.Start();

            t1.Join(); //the main Thread waits until t1 finish
            Console.WriteLine("World");
        }

        private static void SayHello()
        {
            Console.WriteLine("Hello");
        }


        /* ******************************************
        * Example 3 - Demonstrated how a values can be
        * passed/shared between the main Thread and a
        * background thread. 
        * *****************************************/

        public static int ID { get; set; }

        public static void PassingArgument()
        {
            ID = 5;
            Console.WriteLine("ID: " + ID);

            Thread t1 = new Thread(DoSomethingWithTheArgument);
            t1.Start();
            t1.Join();

            Console.WriteLine("ID: " + ID);
        }

        private static void DoSomethingWithTheArgument()
        {
            for (int i = ID; i < ID + 10; i++)
            {
                Console.Write(i + ", ");
            }

            Console.WriteLine();

            ID = -5;
        }

        /* ******************************************
        * Example 4 - Passing Exceptions
        * When using Thread, the Exception can no be passed
        ******************************************/

        public static void Test4()
        {

            //try
            //{
            Thread t1 = new Thread(CreateAnException);
            t1.Start();
            //}
            //catch(AggregateException ex){
            //
            //    Console.WriteLine(ex.Message);
            //}
            //catch
            //{
            //    Console.WriteLine("");
            //}

        }

        private static void CreateAnException(object obj)
        {
            /* *********************************************
             * This exception will not be catch in the main thread.
             * Instead, create the try and cath inside the 
             * unit of code that will be called by different thread
             * throw new Exception("Intentional Exception");
             * *********************************************/

            try
            {
                throw new Exception("Intentional Exception");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }



        /* ******************************************
        * Example 5 - using locks or blocking statement
        * *****************************************/

        public static float Amount { get; set; }
        private static object lock_region = new object();


        public static void Test5()
        {
            float[] items = new float[] { 13.3f, 12.4f, 9.4f, 17.1f, 4f, 3f, 18.8f };

            Thread[] threads = new Thread[6];

            //without lock
            for (int i = 0; i < 3; i++)
            {
                threads[i] = new Thread((x) => SumWithoutLock(items));
            }

            for (int i = 0; i < 3; i++)
            {
                threads[i].Start();
            }

            for (int i = 0; i < 3; i++)
            {
                threads[i].Join();
            }


            // with lock
            for (int i = 3; i < 6; i++)
            {
                threads[i] = new Thread((x) => SumLock(items));
            }

            for (int i = 3; i < 6; i++)
            {
                threads[i].Start();
            }

            for (int i = 3; i < 6; i++)
            {
                threads[i].Join();
            }

        }

        private static void SumWithoutLock(float[] items)
        {
            Amount = 0;

            foreach (float item in items)
            {
                Amount += item;
            }

            Console.WriteLine("The total is {0}", Amount);
        }

        private static void SumLock(float[] items)
        {
            lock (lock_region)
            {
                Amount = 0;

                foreach (float item in items)
                {
                    Amount += item;
                    Thread.Sleep(100);
                }

                Console.WriteLine("The total is {0}", Amount);
            }

        }

        /* ******************************************
        * Example 6 - using locks or blocking statement
        * *****************************************/

        public static bool EnterFlag { get; set; }
        public static bool EnterFlag2 { get; set; }
        public static readonly object lock2 = new object();
        public static readonly object lock3 = new object();

        public static void Test6()
        {
            EnterFlag = false;
            EnterFlag2 = false;

            Thread t1 = new Thread(() =>
            {
                PrintWhenTrue();
                PrintWhenTrue2();
            });
            t1.Start();
            PrintWhenTrue();
            PrintWhenTrue2();
        }

        private static void PrintWhenTrue()
        {
            lock (lock2)
            {
                if (!EnterFlag)
                {
                    Thread.Sleep(1000);
                    EnterFlag = true;
                    Console.WriteLine("Test1 - This line should be printed only once");
                }
            }
        }

        private static void PrintWhenTrue2()
        {
            Monitor.Enter(lock3);

            if (!EnterFlag2)
            {
                Thread.Sleep(1000);
                EnterFlag2 = true;
                Console.WriteLine("Test2 - This line should be printed only once");
            }

            Monitor.Exit(lock3);
        }

        /* ******************************************
        * Example 7 - Threadpool
        * *****************************************/

        public static void Test7()
        {
            Employee employee = new Employee()
            {
                ID = 1,
                Name = "Za"
            };

            Console.WriteLine($"Number of CPUs: {Environment.ProcessorCount}");

            int completionPortThreads;
            int workerThreads;

            ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads);
            ThreadPool.SetMaxThreads(3 * workerThreads, 3 * completionPortThreads);

            ThreadPool.QueueUserWorkItem(new WaitCallback(DisplayEmployeeInfo), employee);

        }

        private class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }


        private static void DisplayEmployeeInfo(object employee)
        {
            Employee emp = (Employee)employee;

            Console.WriteLine($"Name: {emp.Name} and ID: {emp.ID}");
        }
    }
}
