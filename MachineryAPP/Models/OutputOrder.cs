using System;
using System.Collections.Generic;
using System.Text;

namespace MachineryAPP
{
    //Class for the order that will show details to user such as temperature , average ..
    public class OutputOrder
    {
        public int OrderId { get; set; }
        public string Command { get; set; }
        public string MachineId { get; set; }
    }
}
