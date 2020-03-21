using System;
using System.Linq;
using static System.Console;

namespace MachineryAPP
{
    public class OrderManager : IOrderManager
    {
        public MachineManager machineManager = new MachineManager();

        public OrderManager()
        {
        }

        public void TreatOrder(string input)
        {
            string[] order = null;

            if (input != null) order = input.Split(null);
            //Removing spaces from order
            order = order?.Where(val => val != "").ToArray();
            if (order == null)
            {
                Console.WriteLine("Null input : please consider writing a valid input \n");
                Console.WriteLine("enter a new command \n");
            }
            else
            {
                switch (order.Length)
                {
                    case 3:
                    {
                        var inputOrder = GetInputOrder(order);
                        TreatInputOrder(inputOrder);
                        WriteLine();
                        WriteLine("enter a new command \n");
                        break;
                    }
                    case 2:
                    {
                        var outputOrder = GetOutputOrder(order);
                        TreatOutputOrder(outputOrder);
                        WriteLine();
                        WriteLine("enter a new command \n");
                        break;
                    }
                    default:
                        Console.WriteLine("Order not recognized ! please consider reading the documentation");
                        WriteLine();
                        WriteLine("enter a new command \n");
                        break;
                }

            }



        }

        //Transform the input string into an object of type InputOrder
        public InputOrder GetInputOrder(string[] order)
        {
            InputOrder newOrder = new InputOrder
            {
                Command = order[0],
                Param1 = order[1],
                Param2 = order[2]
            };
            return newOrder;
        }

        //Transform the input string into an object of type OutputOrder
        public OutputOrder GetOutputOrder(string[] order)
        {
            OutputOrder newOrder = new OutputOrder
            {
                Command = order[0],
                MachineId = order[1]
            };
            return newOrder;
        }

        //Treatment of the order depending on the order Type : Create / Add/Temperature
        public void TreatInputOrder(InputOrder newOrder)
        {


            //Treating the order depending on the command type
            switch (newOrder.Command.ToLower())
            {
                case "create":
                {
                    Machine machine = new Machine()
                    {
                        MachineName = newOrder.Param1,
                        MachineId = newOrder.Param2
                    };
                    bool result = machineManager.CreateMachine(machine);
                    if (!result)
                        Console.WriteLine(
                            "A machine with the same Identifier already exists ! Please Consider using a different Identifier");
                    break;
                }

                case "add":
                {
                    string machineId = newOrder.Param1;
                    try
                    {
                        int units = Convert.ToInt32(newOrder.Param2);
                        bool val =machineManager.AddUnits(units, machineId);
                        if(!val)
                                Console.WriteLine("Machine not found , please check the machine identifier used");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(
                            "please check the add operations parameters ! The last parameter should be integer");
                    }

                    break;

                }

                case "temperature":
                {
                    string machineId = newOrder.Param1;
                    try
                    {
                        int temperature = Convert.ToInt32(newOrder.Param2);
                        bool val = machineManager.SetTemperature(temperature, machineId);
                        if(!val)
                             Console.WriteLine("Machine not found , please check the machine identifier used");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(
                            "please check the add operations parameters ! The last parameter should be integer");
                    }
                    break;
                }
                default:
                {
                    Console.WriteLine(
                        "please check the  operations parameters ! Order not recognized");
                    break;
                }
            }
        }
    
    //Treatment of the order depending on the order Type : Total / Average /Temperature ...

    public void TreatOutputOrder(OutputOrder newOrder)
    {
        switch (newOrder.Command)
        {
            case "temperature":
            {
                int? temp = machineManager.GetTemperature(newOrder.MachineId);

                if (temp != null)
                    WriteLine("temperature is {0}", temp);
                else
                    WriteLine("Machine not found ! please verify the machine Identifier");
                break;

            }
            case "total":
            {
                int? total = machineManager.GetTotal(newOrder.MachineId);

                if (total != null)
                    WriteLine("total is {0}", total);
                else
                    WriteLine("Machine not found ! please verify the machine Identifier");
                break;
            }
            case "average":
            {
                int? avg = machineManager.GetAverage(newOrder.MachineId);

                if (avg != null)
                    WriteLine("average is {0}", avg);
                else
                    WriteLine("Machine not found ! please verify the machine Identifier");
                break;
            }
            default:
            {
                Console.WriteLine(
                    "please check the  operations parameters ! Order not recognized");
                break;
            }
        }


    }
}

}

