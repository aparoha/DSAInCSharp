using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.LockerManagement.Strategy
{
    public class DefaultRandomGenerator : IRandomGenerator
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public int GetRandomNumber(int lessThanThis)
        {
            lock (syncLock)
            { 
                return random.Next(lessThanThis);
            }
        }
    }
}
