using System;
using System.Linq;
using static System.Console;

namespace MachineryAPP
{
    public class OrderManager : IOrderManager
    {
        //public MachineManager machineManager = new MachineManager();
        private IMachineManager machineManager;
        public OrderManager(IMachineManager machineMgr)
        {
            machineManager = machineMgr;
        }
        public OrderManager() { }
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
                        string final = TreatInputOrder(inputOrder);
                            Console.WriteLine("{0}", final);
                        WriteLine();
                        WriteLine("enter a new command \n");
                        break;
                    }
                    case 2:
                    {
                        var outputOrder = GetOutputOrder(order);
                        int? final = TreatOutputOrder(outputOrder);
                            
                            if (final!=null)
                            Console.WriteLine("{0}", final);
                            else
                            Console.WriteLine("An error occured");
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
        public string TreatInputOrder(InputOrder newOrder)
        {

            string final;
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
                        if (result==false)
                            final = "A machine with the same Identifier already exists ! Please Consider using a different Identifier";
                        else
                            final = "success";
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
                                final="Machine not found , please check the machine identifier used";
                        else
                            final = "success";
                    }
                    catch (Exception ex)
                    {
                        
                           final= "please check the add operations parameters ! The last parameter should be integer";
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
                            if (!val)
                                final = "Machine not found , please check the machine identifier used";
                            else
                                final = "success";
                    }
                    catch (Exception ex)
                    {
                        
                           final= "please check the add operations parameters ! The last parameter should be integer";
                    }
                    break;
                }
                default:
                {
                    final= "please check the  operations parameters ! Order not recognized";
                    break;
                }
            }
            return final;
        }
    
    //Treatment of the order depending on the order Type : Total / Average /Temperature ...

    public int? TreatOutputOrder(OutputOrder newOrder)
    {
        int? final;
        switch (newOrder.Command)
        {
            case "temperature":
            {
                int? temp = machineManager.GetTemperature(newOrder.MachineId);

                        final = temp;
                break;

            }
            case "total":
            {
                int? total = machineManager.GetTotal(newOrder.MachineId);
                        final = total;
                
                break;
            }
            case "average":
            {
                int? avg = machineManager.GetAverage(newOrder.MachineId);
                        final = avg;   
                break;
            }
            default:
            {
                final=null;
                break;
            }
        }
            return final;

    }
}

}

