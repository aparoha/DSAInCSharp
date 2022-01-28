using DSAProblems.LLD.LockerManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.LockerManagement.Strategy
{
    public interface ISlotFilteringStrategy
    {
        List<Slot> Filter(List<Slot> slots, Package lockerItem);
    }
}
