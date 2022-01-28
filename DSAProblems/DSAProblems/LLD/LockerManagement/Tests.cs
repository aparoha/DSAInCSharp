using DSAProblems.LLD.LockerManagement.Controller;
using DSAProblems.LLD.LockerManagement.Model;
using DSAProblems.LLD.LockerManagement.Repository;
using DSAProblems.LLD.LockerManagement.Service;
using DSAProblems.LLD.LockerManagement.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.LockerManagement
{
    [TestClass]
    public class Lockertests
    {
        [TestMethod]
        public void TestSlotAllocationToUser()
        {
            DefaultRandomGenerator defaultRandom = new DefaultRandomGenerator();
            ISlotAssignmentStrategy lockerAssignmentStrategy = new RandomSlotAssignmentStrategy(defaultRandom);
            ILockerRepository lockerRepository = new InMemoryLockerRepository();
            ISlotFilteringStrategy slotFilteringStrategy = new SizeBasedSlotFilteringStrategy();
            InMemoryOtprepository slotOtpRepository = new InMemoryOtprepository();
            RandomOtpGenerator otpGeneratorRandom = new RandomOtpGenerator(5, defaultRandom);

            var lockerService = new LockerService(lockerAssignmentStrategy, lockerRepository, slotFilteringStrategy);
            CreateTestLockerWithSlots(new LockerController(lockerService), 2, new Size(10.0, 10.0));
        }

        private Locker CreateTestLockerWithSlots(LockerController lockerController, int numSlots, Size slotSize)
        {
            var locker = lockerController.Create(Guid.NewGuid().ToString());
            for(int i = 0; i < numSlots; i++)
                lockerController.Create(locker, slotSize);
            return locker;
        }
    }
}
