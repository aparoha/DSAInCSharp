using DSAProblems.LLD.LockerManagement.Model;
using DSAProblems.LLD.LockerManagement.Repository;
using DSAProblems.LLD.LockerManagement.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.LockerManagement.Service
{
    public class LockerService
    {
        readonly private ISlotAssignmentStrategy _slotAssignmentStrategy;
        readonly private ILockerRepository _lockerRepository;
        readonly private ISlotFilteringStrategy _slotFilteringStrategy;

        public LockerService(ISlotAssignmentStrategy slotAssignmentStrategy,
            ILockerRepository lockerRepository, ISlotFilteringStrategy slotFilteringStrategy)
        {
            _slotAssignmentStrategy = slotAssignmentStrategy;
            _lockerRepository = lockerRepository;
            _slotFilteringStrategy = slotFilteringStrategy;
        }

        public Locker Create(string lockerId)
        {
            return _lockerRepository.Create(lockerId);
        }

        public Slot Create(Locker locker, Size slotSize)
        {
            Slot slot = new Slot(System.Guid.NewGuid().ToString(), slotSize);
            locker.AddSlot(slot);
            return slot;
        }

        public List<Slot> GetAllAvailableSlots()
        {
            return _lockerRepository.GetAvailableSlots();
        }

        public Slot AllocateSlot(Package lockerItem)
        {
            var allAvailableSlots = _lockerRepository.GetAvailableSlots();
            var filterSlots = _slotFilteringStrategy.Filter(allAvailableSlots, lockerItem);
            Slot slotToBeAllocated = _slotAssignmentStrategy.Pick(filterSlots);
            if(slotToBeAllocated == null)
                throw new Exception("No slot available");
            slotToBeAllocated.AllocatePackage(lockerItem);
            return slotToBeAllocated;
         }

        public void DeAllocateSlot(Slot slot)
        {
            slot.DeAllocateSlot();
        }


    }
}
