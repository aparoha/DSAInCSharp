using DSAProblems.LLD.LockerManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.LockerManagement.Strategy
{
    public class RandomSlotAssignmentStrategy : ISlotAssignmentStrategy
    {
        readonly private IRandomGenerator _randomGenerator;
        public RandomSlotAssignmentStrategy(IRandomGenerator randomGenerator)
        {
            _randomGenerator = randomGenerator;
        }
        public Slot Pick(List<Slot> slots)
        {
            if(slots.Count == 0)
                return null;
            return slots[_randomGenerator.GetRandomNumber(slots.Count)];
        }
    }
}
