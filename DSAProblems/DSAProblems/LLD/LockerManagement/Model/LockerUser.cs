using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.LockerManagement.Model
{
    public abstract class LockerUser
    {
        private readonly Contact _contact;

        protected LockerUser(Contact contact)
        {
            _contact = contact;
        }

        public Contact Contact => _contact;
    }
}
