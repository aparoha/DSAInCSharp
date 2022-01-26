using DSAProblems.LLD.ParkingLot.Model;
using DSAProblems.LLD.ParkingLot.Model.ParkingStrategy;
using System.Collections.Generic;

namespace DSAProblems.LLD.ParkingLot.Service
{
    /* Service to enable the functioning of a parking lot. This will have the business logic of
     * how the parking service will operate
    */
    public class ParkingLotService
    {
        private readonly Model.ParkingLot _parkingLot;

        public ParkingLotService(Model.ParkingLot parkingLot)
        {
            _parkingLot = parkingLot;
        }

        public int Park(Car car)
        {
            return _parkingLot.Park(car).SlotNumber;
        }

        public void MakeSlotFree(int slotNumber)
        {
            _parkingLot.MarkFree(slotNumber);
        }

        public List<Slot> GetOccupiedSlots()
        {
            List<Slot> occupiedSlots = new List<Slot>();
            Dictionary<int, Slot> slots = _parkingLot.Slots;
            for(int i = 1; i<= _parkingLot.Capacity; i++)
            {
                if(slots.ContainsKey(i) && !slots[i].IsSlotFree)
                    occupiedSlots.Add(slots[i]);
            }
            return occupiedSlots;
        }

    }
}
