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
            Console.WriteLine("3 - Task Asynchronous Pattern");

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
                    Console.WriteLine("2 selected");
                    //MT002_task.Example2();
                    MT002_task.Example3();
                }
                else if (cki.Key == ConsoleKey.D3)
                {
                    Console.WriteLine("3 selected");
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
            }
        }
    }
}
