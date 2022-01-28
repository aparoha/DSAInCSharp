using DSAProblems.LLD.LockerManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.LockerManagement.Strategy
{
    public class SizeBasedSlotFilteringStrategy : ISlotFilteringStrategy
    {
        public List<Slot> Filter(List<Slot> slots, Package lockerItem)
        {
            return slots.Where(slot => slot.Size.CanAccomadate(lockerItem.Size)).ToList();
        }
    }
}
