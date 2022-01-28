using DSAProblems.LLD.LockerManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.LockerManagement.Repository
{
    public class InMemoryLockerRepository : ILockerRepository
    {
        readonly private List<Locker> _allLockers;
        public InMemoryLockerRepository()
        {
            _allLockers = new List<Locker>();
        }
        public Locker GetLocker(string id)
        {
            foreach (var locker in _allLockers.Where(locker => locker.Id == id))
                return locker;
            return null;
        }

        public List<Slot> GetAvailableSlots()
        {
            List<Slot> result = new List<Slot>();
            foreach(var locker in _allLockers)
                result.AddRange(locker.GetAvailableSlots());
            return result;
        }

        public Locker Create(string id)
        {
            if(GetLocker(id) != null)
                throw new Exception("Locker already exists");
            Locker newLocker = new Locker(id);
            _allLockers.Add(newLocker);
            return newLocker;
        }
    }
}
