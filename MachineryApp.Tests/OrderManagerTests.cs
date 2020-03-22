using MachineryAPP;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class OrderManagerTests
    {

        [Test]
        public void TreatInputOrder_CreateMachineFromStringInput_returnTrue()
        {
            InputOrder io = new InputOrder()
            {
                Command = "create",
                Param1 = "MACHINE1",
                Param2 = "IDX123456"
            };
            Machine maskin = new Machine()
            {
                MachineId = "IDX123456",
                MachineName = "MACHINE1"
            };
            var mockMgr = new Mock<IMachineManager>();
            //mockMgr.Setup(x => x.CreateMachine(maskin)).Returns(true);
            mockMgr.Setup(x => x.CreateMachine(It.IsAny<Machine>())).Returns(() => true);
            OrderManager ordM = new OrderManager(mockMgr.Object);
            Assert.AreEqual(ordM.TreatInputOrder(io), "success");
        }

        [Test]
        public void TreatInputOrder_SetMachineTemperature_returnTrue()
        {
            InputOrder io = new InputOrder()
            {
                Command = "temperature",
                Param1 = "IDX123456",
                Param2 = "120"
            };
            //Machine maskin = new Machine()
            //{
            //    MachineId = "IDX123456",
            //    MachineName = "Maskina"
            //};
            var mockMgr = new Mock<IMachineManager>(MockBehavior.Strict);
            //mockMgr.Setup(x => x.CreateMachine(It.IsAny<Machine>())).Returns(()=>true);
            mockMgr.Setup(x => x.SetTemperature(120, "IDX123456")).Returns(true);
            var ordM = new OrderManager(mockMgr.Object);

            Assert.AreEqual(ordM.TreatInputOrder(io), "success");
        }

        //[Test]
        //public void TreatInputOrder_AddUnitsToMachine_returnTrue()
        //{
        //    string str = "create MACHINE1 IDX123456";
        //    string[] input = new string[] { "add", "IDX123456", "120" };
        //    OrderManager ordM = new OrderManager();
        //    ordM.TreatOrder(str);
        //    InputOrder order = ordM.GetInputOrder(input);
        //    ordM.TreatInputOrder(order);
        //    Assert.IsNotNull(ordM.machineManager.Machines.FirstOrDefault(x => x.TotalUnits == 120));
        //    Assert.IsNotNull(ordM.machineManager.Machines.FirstOrDefault(x=>x.AddOrderCount==1));

        //    string[] input1 = new string[] { "add", "IDX123456", "10" };
        //    InputOrder order2 = ordM.GetInputOrder(input1);
        //    ordM.TreatInputOrder(order2);
        //    Assert.IsNotNull(ordM.machineManager.Machines.FirstOrDefault(x => x.TotalUnits == 130));
        //    Assert.IsNotNull(ordM.machineManager.Machines.FirstOrDefault(x => x.AddOrderCount == 2));

        //}

        [Test]
        public void GetInputOrder_CreateInputCreateOrderFromArrayOfString_returnTrue()
        {
            string[] input = new string[] { "create", "machine2", "IDX147852" };
            OrderManager ordM = new OrderManager();
            InputOrder inputOrder = ordM.GetInputOrder(input);
            Assert.IsTrue(inputOrder.Command == "create");
            Assert.IsTrue(inputOrder.Param1 == "machine2");
            Assert.IsTrue(inputOrder.Param2 == "IDX147852");
        }

        [Test]
        public void GetInputOrder_AddInputOrderFromArrayOfString_returnTrue()
        {
            string[] input = new string[] { "add", "IDX147852", "25" };
            OrderManager ordM = new OrderManager();
            InputOrder inputOrder = ordM.GetInputOrder(input);
            Assert.IsTrue(inputOrder.Command == "add");
            Assert.IsTrue(inputOrder.Param1 == "IDX147852");
            Assert.IsTrue(inputOrder.Param2 == "25");
        }

        [Test]
        public void GetInputOrder_TemperatureInputOrderFromArrayOfString_returnTrue()
        {
            string[] input = new string[] { "temperature", "IDX147852", "120" };
            OrderManager ordM = new OrderManager();
            InputOrder inputOrder = ordM.GetInputOrder(input);
            Assert.IsTrue(inputOrder.Command == "temperature");
            Assert.IsTrue(inputOrder.Param1 == "IDX147852");
            Assert.IsTrue(inputOrder.Param2 == "120");
        }

        [Test]
        public void GetOutputOrder_CreateOutputOrderFromArrayOfString_returnTrue()
        {
            string[] output = new string[] { "temperature", "IDX147852" };
            OrderManager ordM = new OrderManager();
            OutputOrder outputOrder = ordM.GetOutputOrder(output);
            Assert.IsTrue(outputOrder.Command == "temperature");
            Assert.IsTrue(outputOrder.MachineId == "IDX147852");
        }

        [Test]
        public void GetOutputOrder_CreateOutputAverageOrderFromArrayOfString_returnTrue()
        {
            string[] output = new string[] { "average", "IDX147852" };
            OrderManager ordM = new OrderManager();
            OutputOrder outputOrder = ordM.GetOutputOrder(output);
            Assert.IsTrue(outputOrder.Command == "average");
            Assert.IsTrue(outputOrder.MachineId == "IDX147852");
        }

        [Test]
        public void GetOutputOrder_CreateOutputTotalOrderFromArrayOfString_returnTrue()
        {
            string[] output = new string[] { "total", "IDX147852" };
            OrderManager ordM = new OrderManager();
            OutputOrder outputOrder = ordM.GetOutputOrder(output);
            Assert.IsTrue(outputOrder.Command == "total");
            Assert.IsTrue(outputOrder.MachineId == "IDX147852");
        }
    }
}