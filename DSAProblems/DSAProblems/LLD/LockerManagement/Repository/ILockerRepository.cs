using DSAProblems.LLD.LockerManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.LockerManagement.Repository
{
    public interface ILockerRepository
    {
        Locker Create(string id);
        List<Slot> GetAvailableSlots();
    }
}
