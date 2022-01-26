namespace DSAProblems.LLD.ParkingLot.Model
{
    public class Slot
    {
        public Car ParkedCar { get; private set; }
        public int SlotNumber { get; private set; }
        public bool IsSlotFree { get { return ParkedCar == null;} }
        public Slot(int slotNumber)
        {
            SlotNumber = slotNumber;
        }

        public void AssignCar(Car car)
        {
            ParkedCar = car;
        }

        public void UnAssignCar()
        {
            ParkedCar = null;
        }
    }
}
