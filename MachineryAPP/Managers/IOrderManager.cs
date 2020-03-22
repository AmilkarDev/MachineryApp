namespace MachineryAPP
{
    public interface IOrderManager
    {
        void TreatOrder(string input);
        InputOrder GetInputOrder(string[] order);
        OutputOrder GetOutputOrder(string[] order);
        string TreatInputOrder(InputOrder newOrder);
        int? TreatOutputOrder(OutputOrder newOrder);
    }
}