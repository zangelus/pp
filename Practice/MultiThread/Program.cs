using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MultiThread
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter an option to continue: ");
            Console.WriteLine("1 - Thread");
            Console.WriteLine("2 - Task");
            Console.WriteLine("3 - Syncronization");
            Console.WriteLine("4 - Task Asynchronous Pattern");

            ConsoleKeyInfo cki = Console.ReadKey();
            Console.Clear();

            while (cki.Key != ConsoleKey.Escape)
            {
                if(cki.Key == ConsoleKey.D1)
                {
                    Console.WriteLine("1 selected");
                }
                else if (cki.Key == ConsoleKey.D2)
                {
                    Console.WriteLine("Task section selected");
                    Console.WriteLine("Enter an option to continue: ");
                    Console.WriteLine("1- Task return void");
                    Console.WriteLine("2- Task return string");
                    Console.WriteLine("3- Task return IO operation");
                    Console.WriteLine("4- Task delay example");
                    Console.WriteLine("5- Task delay with return data");
                    Console.WriteLine("6- Task async await big for loop return data");
                    Console.WriteLine("7- Task continuation");

                    cki = Console.ReadKey();
                    Console.Clear();

                    if (cki.Key == ConsoleKey.D1)
                    {
                        MT002_task.Example1();
                    }
                    else if (cki.Key == ConsoleKey.D2)
                    {
                        MT002_task.Example2();
                    }
                    else if (cki.Key == ConsoleKey.D3)
                    {
                        MT002_task.Example3();
                    }
                    else if (cki.Key == ConsoleKey.D4)
                    {
                        MT002_task.Task_Delay_Operation();
                    }
                    else if (cki.Key == ConsoleKey.D5)
                    {
                        MT002_task.Task_Delay_return_data();
                    }
                    else if (cki.Key == ConsoleKey.D6)
                    {
                        MT002_task.Task_for_loop_return_data();
                    }
                    else if (cki.Key == ConsoleKey.D7)
                    {
                        MT002_task.TaskContinuation();
                    }
                }
                else if (cki.Key == ConsoleKey.D3)
                {
                    Console.WriteLine("3 selected");
                    MT003_syncronization.Locks();
                }
                else if (cki.Key == ConsoleKey.D4)
                {
                    Console.WriteLine("4 selected");
                    MT020_TAP.Example1();
                }
                else
                {
                    Console.WriteLine("Not a valid option");
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
                
                Console.WriteLine("Enter an option to continue: ");

                Console.WriteLine("1 - Thread");
                Console.WriteLine("2 - Task");
                Console.WriteLine("3 - Task Asynchronous Pattern");

                cki = Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
