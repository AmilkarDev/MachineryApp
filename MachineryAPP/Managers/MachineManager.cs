using System.Collections.Generic;
using System.Linq;

namespace MachineryAPP
{
    public class MachineManager : IMachineManager
    {
        //List of all the machines added since the program launch
       public List<Machine> Machines = new List<Machine>();

        
        public bool CreateMachine(Machine machine)
        {
            var maskins = Machines.Where(x => x.MachineId == machine.MachineId).ToList();
            if (maskins.Count != 0) return false;
            Machines.Add(machine);
            return true;


        }

        public bool AddUnits(int units,string machineId)
        {
            Machine machine = Machines.FirstOrDefault(x => x.MachineId.Equals(machineId));
            if (machine != null)
            {
                machine.TotalUnits += units;
                machine.AddOrderCount++;
                return true;
            }

            return false;
        }

        public bool SetTemperature(int temperature,string machineId)
         {
            Machine machine = Machines.FirstOrDefault(x => x.MachineId == machineId);
            if (machine != null)
            {
                machine.Temperature = temperature;
                return true;
            }

            return false;
        }



        #region  OutputResultsRegion

        public int? GetTemperature(string machineId)
        { 
            Machine machine = Machines.FirstOrDefault(x => x.MachineId == machineId);
            return machine?.Temperature;
        }

        public int? GetTotal(string machineId)
        {
            Machine machine = Machines.FirstOrDefault(x => x.MachineId == machineId);
            return machine?.TotalUnits;
        }

        public int? GetAverage(string machineId)
        {
            Machine machine = Machines.FirstOrDefault(x => x.MachineId.Equals(machineId));
            if (machine != null)
                return machine.TotalUnits / machine.AddOrderCount;
            else
                return null;
        }
        #endregion



    }

    
}
