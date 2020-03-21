using System.Collections.Generic;

namespace MachineryAPP
{
    public interface IMachineManager
    {
        
        bool CreateMachine(Machine machine);
        bool AddUnits(int units,string machineId);
        bool SetTemperature(int temperature,string machineId);
        int? GetTemperature(string machineId);
        int? GetTotal(string machineId);
        int? GetAverage(string machineId);
    }
}