namespace MachineryAPP
{
    public interface IOrderManager
    {
        void TreatOrder(string input);
        InputOrder GetInputOrder(string[] order);
        OutputOrder GetOutputOrder(string[] order);
        void TreatInputOrder(InputOrder newOrder);
        void TreatOutputOrder(OutputOrder newOrder);
    }
}