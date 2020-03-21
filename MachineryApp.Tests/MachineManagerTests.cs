using System.Linq;
using MachineryAPP;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace MachineryApp.Tests
{

    public class MachineManagerTests
    {
        [Test]
        public void CreateMachine_VerifyNotPossibleToAddNewMachineWithAnExistingId_returnFalse()
        {
            Machine machine = new Machine()
            {
                MachineId = "IDX147",
                MachineName = "Machine147"
            };
            Machine machine1 = new Machine()
            {
                MachineId = "IDX147",
                MachineName = "Machine1"
            };
            MachineManager machineMgr = new MachineManager();
            bool val1=machineMgr.CreateMachine(machine);
            Assert.IsTrue(val1);
            bool val =machineMgr.CreateMachine(machine1);
            Assert.IsFalse(val);
        }
        [Test]
        public void CreateMachine_VerifyMachineExistsInListOfMachines_ReturnTrue()
        {
            Machine machine = new Machine()
            {
                MachineId = "IDX147",
                MachineName = "Machine147"
            };
            MachineManager machineMgr = new MachineManager();
            machineMgr.CreateMachine(machine);
            Assert.IsNotNull(machineMgr.Machines.FirstOrDefault(x=>x.MachineName=="Machine147"&&x.MachineId=="IDX147"));
        }

        [Test]
        public void AddUnits_VerifyTotalUnitsUpdate_ReturnTrue()
        {
            Machine machine = new Machine()
            {
                MachineId = "IDX147",
                MachineName = "Machine147"
            };
            MachineManager machineMgr = new MachineManager();
            machineMgr.CreateMachine(machine: machine);
            machineMgr.AddUnits(units: 150, machineId: "IDX147");
            Assert.IsNotNull(machineMgr.Machines.FirstOrDefault(x=>x.MachineId== "IDX147"));
            Assert.IsNotNull(anObject: machineMgr.Machines.FirstOrDefault(predicate: m=>m.TotalUnits==150));
            machineMgr.AddUnits(units: 10, machineId: "IDX147");
            Assert.IsTrue(condition: machineMgr.Machines.FirstOrDefault( m => m.MachineId == "IDX147").TotalUnits==160);

        }

        [Test]
        public void SetTemperature_SetAndUpdateMachineTemperature_ReturnTrue()
        {
            Machine machine = new Machine()
            {
                MachineId = "IDX147",
                MachineName = "Machine147"
            };
            MachineManager machineMgr = new MachineManager();
            machineMgr.CreateMachine(machine: machine);
            machineMgr.SetTemperature(120,machine.MachineId);
            Assert.IsNotNull(machineMgr.Machines.FirstOrDefault(x => x.MachineId == "IDX147"));
            Machine maskin = machineMgr.Machines.FirstOrDefault(m => m.MachineId == machine.MachineId);
            Assert.IsTrue(maskin != null && maskin.Temperature == 120);

            //Verify setTemperature after update Operation
            machineMgr.SetTemperature(60, machine.MachineId);
            Machine maskin1 = machineMgr.Machines.FirstOrDefault(m => m.MachineId == machine.MachineId);
            Assert.IsTrue(maskin1!= null && maskin1.Temperature == 60);
        }




        [Test]
        public void GetTemperature_GetTemperatureUsingMachineId_ReturnTrue()
        {
            Machine machine = new Machine()
            {
                MachineId = "IDX147",
                MachineName = "Machine147"
            };
            MachineManager machineMgr = new MachineManager();
            machineMgr.CreateMachine(machine: machine);
            machineMgr.SetTemperature(120, machine.MachineId);
            int? temp = machineMgr.GetTemperature(machine.MachineId);
            Assert.IsTrue(temp!=null&&temp==120);
        }

        [Test]
        public void GetTotal_GetTotalUsingMachineId_ReturnTrue()
        {
            Machine machine = new Machine()
            {
                MachineId = "IDX147",
                MachineName = "Machine147"
            };
            MachineManager machineMgr = new MachineManager();
            machineMgr.CreateMachine(machine: machine);
            machineMgr.AddUnits(120, machine.MachineId);
            int? total = machineMgr.GetTotal(machine.MachineId);
            Assert.IsTrue(total != null && total == 120);
        }
        [Test]
        public void GetAverage_GetAverageUsingMachineId_ReturnTrue()
        {
            Machine machine = new Machine()
            {
                MachineId = "IDX147",
                MachineName = "Machine147"
            };
            MachineManager machineMgr = new MachineManager();
            machineMgr.CreateMachine(machine: machine);
            machineMgr.AddUnits(120, machine.MachineId);
            machineMgr.AddUnits(150, machine.MachineId);
            int? avg = machineMgr.GetAverage(machine.MachineId);
            Assert.IsTrue(avg != null && avg == 135);
        }

    }
}
