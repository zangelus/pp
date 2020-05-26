using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{
    public class MT003_syncronization
    {
        /* Two types of lock
         * 1- Exclusive lock: Allow only one thread at a time to access a resource
         * 1.1 - lock or Monitor.Enter/Monitor.Exit. The scope is the application/process
         * 1.2 - Mutex (system level / inter process locking)
         * 2- Non-Exclusive locking: Allow multipli threads to access a resource
         * 2.1 - Semaphore. A semaphore = 1 is equivalent to a Mutex
         * 2.2 - Semaphore slim
         * 2.3 - Reader/Writer
        */

        public static int total;
        private static object za = new object();

        public static void Locks()
        {
            total = 50000;
            Console.WriteLine($"Total amount is: {total}");

            int[] toWithdraw = new int[6] { 1500, 2500, 3800, 4500, 7450, 9560 };
            int[] toDeposit  = new int[6] { 1500, 2500, 3800, 4500, 7450, 9560 };

            var tasks = new List<Task>();

            for (int i = 0; i<toWithdraw.Length; i++)
            {
                int value = toWithdraw[i];
                tasks.Add(new Task(() => Withdraw(value)));
                //tasks.Add(Task.Run(() => Withdraw(toWithdraw[i])));
            }

            for (int i = toDeposit.Length -1; i >= 0; i--)
            {
                int value = toDeposit[i];
                tasks.Add(new Task(() => Deposit(value)));
                //tasks.Add(Task.Run(() => Deposit(toDeposit[i])));
            }

            foreach(var task in tasks)
            {
                task.Start();
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine($"Total amount is: {total}");
        }

        private static void Withdraw(int amount)
        {
            //if (total < 0) throw new Exception("not good");
            lock (za)
            {
                Thread.Sleep(100);
                total = total - amount;
                Console.WriteLine("Task id: " + Task.CurrentId);
            }
        }

        private static void Deposit(int amount)
        {
            lock (za)
            {
                Thread.Sleep(100);
                total = total + amount;
                Console.WriteLine("Task id: " + Task.CurrentId);
            }
        }

    }
}
