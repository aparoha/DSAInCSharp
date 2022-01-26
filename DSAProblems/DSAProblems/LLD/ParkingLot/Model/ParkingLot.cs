using DSAProblems.LLD.ParkingLot.Model.ParkingStrategy;
using System;
using System.Collections.Generic;

namespace DSAProblems.LLD.ParkingLot.Model
{
    public class ParkingLot
    {
        private const int Max_CAPACITY = 100000;
        private readonly IParkingStrategy _parkingStrategy;
        public Dictionary<int, Slot> Slots { get; private set; }
        public int Capacity { get; private set;}

        public ParkingLot(int capacity, IParkingStrategy parkingStrategy)
        {
            if(capacity > Max_CAPACITY || capacity <= 0)
                throw new Exception("Invalid capacity given for parking lot");
            Capacity = capacity;
            Slots = new Dictionary<int, Slot>();
            _parkingStrategy = parkingStrategy;
            for (int i = 1; i <= Capacity; i++)
                _parkingStrategy.AddSlot(i);
        }

        public Slot Park(Car car)
        {
            int nextFreeSlot = _parkingStrategy.GetNextSlot();
            Slot slot = GetSlot(nextFreeSlot);
            if(!slot.IsSlotFree)
                throw new Exception("Slot already occupied");
            slot.AssignCar(car);
            _parkingStrategy.RemoveSlot(nextFreeSlot);
            return slot;
        }

        public Slot MarkFree(int slotNumber)
        {
            Slot slot = GetSlot(slotNumber);
            slot.UnAssignCar();
            _parkingStrategy.RemoveSlot(slotNumber);
            return slot;
        }

        private Slot GetSlot(int slotNumber)
        {
            if (slotNumber > Max_CAPACITY || slotNumber <= 0)
                throw new Exception("Invalid slot number given for slot");
            if (!Slots.ContainsKey(slotNumber))
                Slots.Add(slotNumber, new Slot(slotNumber));
            return Slots[slotNumber];
        }
    }
}
