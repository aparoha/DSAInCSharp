using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.LockerManagement.Repository
{
    public interface ISlotOtpRepository
    {
        void Add(string otp, string slotId);
        string Get(string slotId);
    }
}
