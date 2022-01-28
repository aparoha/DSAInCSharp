using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.LockerManagement.Strategy
{
    public interface IRandomGenerator
    {
        int GetRandomNumber(int lessThanThis);
    }
}
