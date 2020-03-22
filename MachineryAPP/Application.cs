using System;

namespace MachineryAPP
{
    public class Application: IApplication
    {
        private IOrderManager orderManager;
        public Application(IOrderManager orderMgr)
        {
            orderManager = orderMgr;
        }

        public void Run()
        {
            LaunchApp();
        }

        private void LaunchApp()
        {
            Console.WriteLine("Welcome to the Machinery App");
            Console.Write("Enter Command: \n");
            string command = "";

            while (command != "exit")
            {
                command = Console.ReadLine();
                orderManager.TreatOrder(command);

            }
            Console.ReadKey();
        }
    }
}
