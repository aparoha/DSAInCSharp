namespace DSAProblems.LLD.ParkingLot.Model.ParkingStrategy
{
    public interface IParkingStrategy
    {
        void AddSlot(int slotNumber);
        void RemoveSlot(int slotNumber);
        int GetNextSlot();
    }
}
