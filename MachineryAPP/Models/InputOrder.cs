
namespace MachineryAPP
{
    //Class for details entered by the user (User Input) such as new machines , updating temperature , totalUnits, average ...
    public class InputOrder
    {
        
        public int OrderId  { get; set; }
        public string Command { get; set; }
        public string Param1 { get; set; }
        public string Param2 { get; set; }
    }
}