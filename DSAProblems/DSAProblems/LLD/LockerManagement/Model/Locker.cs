using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.LockerManagement.Model
{
    public class Locker
    {
        readonly private string _id;
        readonly private List<Slot> _slots;

        public Locker(string id)
        {
            _id = id;
            _slots = new List<Slot>();
        }

        public string Id => _id;

        public void AddSlot(Slot newSlot)
        {
            _slots.Add(newSlot);
        }

        public List<Slot> GetAvailableSlots()
        {
            List<Slot> result = new List<Slot>();
            foreach(var slot in _slots)
            {
                if(slot.IsAvailable())
                    result.Add(slot);
            }
            return result;
        }
    }
}
