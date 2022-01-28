using System;

namespace DSAProblems.LLD.LockerManagement.Model
{
    public class Slot
    {
        readonly private string _slotId;
        readonly private Size _size;
        private Package _currentLockerItem;
        private DateTime _allocationDate;

        public Size Size => _size;

        public Slot(string slotId, Size size)
        {
            _slotId = slotId;
            _size = size;
            _currentLockerItem = null;
        }

        public bool IsAvailable()
        {
            return _currentLockerItem == null;
        }

        public void DeAllocateSlot()
        {
            _currentLockerItem = null;
        }

        public void AllocatePackage(Package lockerItem)
        {
            if(_currentLockerItem != null)
                throw new Exception("Slot occupied");
            _allocationDate = DateTime.Now;
            _currentLockerItem = lockerItem;
        }
    }
}
