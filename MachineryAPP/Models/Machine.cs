using System;
using System.Collections.Generic;
using System.Text;

namespace MachineryAPP
{
    public class Machine
    {
        public string MachineId { get; set; }
        public string MachineName { get; set; }
        public int Temperature { get; set; }
        public int TotalUnits { get; set; }
        // the number of orders that updated the totalUnits of the machine
        //each input from the user to the commandLined is treated as ORDER
        public int AddOrderCount { get; set; }

    }
}
