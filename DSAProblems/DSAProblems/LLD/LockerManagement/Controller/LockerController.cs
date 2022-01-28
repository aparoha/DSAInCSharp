using DSAProblems.LLD.LockerManagement.Model;
using DSAProblems.LLD.LockerManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.LockerManagement.Controller
{
    public class LockerController
    {
        readonly private LockerService _lockerService;
        public LockerController(LockerService lockerService)
        {
            _lockerService = lockerService;
        }

        public Locker Create(string lockerId)
        {
            return _lockerService.Create(lockerId);
        }

        public Slot Create(Locker locker, Size slotSize)
        {
            return _lockerService.Create(locker, slotSize);
        }

        public List<Slot> GetSlots()
        {
            return _lockerService.GetAllAvailableSlots();
        }

        public void DeAllocateSlot(Slot slot)
        {
            _lockerService.DeAllocateSlot(slot);
        }
    }
}
