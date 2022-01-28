using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.LockerManagement.Repository
{
    public class InMemoryOtprepository : ISlotOtpRepository
    {
        readonly private Dictionary<string, string> _slotIdToOtpMap;
        public InMemoryOtprepository()
        {
            _slotIdToOtpMap = new Dictionary<string, string>();
        }
        public void Add(string otp, string slotId)
        {
            _slotIdToOtpMap.Add(slotId, otp);
        }

        public string Get(string slotId)
        {
            return _slotIdToOtpMap[slotId];
        }
    }
}
