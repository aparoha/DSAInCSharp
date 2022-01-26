using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.ParkingLot.Model.ParkingStrategy
{
    public class NaturalOrderParkingStrategy : IParkingStrategy
    {
        private SortedSet<int> _slotsSet;

        public NaturalOrderParkingStrategy()
        {
            _slotsSet = new SortedSet<int>();
        }
        public void AddSlot(int slotNumber)
        {
            _slotsSet.Add(slotNumber);
        }

        public int GetNextSlot()
        {
            if(_slotsSet.Count == 0)
                throw new Exception("No free slot available");
            return _slotsSet.First();
        }

        public void RemoveSlot(int slotNumber)
        {
            _slotsSet.Remove(slotNumber);
        }
    }
}
