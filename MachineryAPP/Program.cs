using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Transactions;
using static System.Console;

namespace MachineryAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] order = null;
            OrderManager orderManager = new OrderManager();
            WriteLine("Welcome to the Machinery App");
            Write("Enter Command: \n");
            string command = "";

            while(command != "exit")
            {
                command = ReadLine();
                orderManager.TreatOrder(command);
               
            }

           

            //WriteLine("Your input: {0}", a);
            ReadKey();
            //Console.ReadLine();
        }
    }
}
