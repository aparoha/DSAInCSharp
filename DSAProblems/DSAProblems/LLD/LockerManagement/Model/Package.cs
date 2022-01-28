using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.LockerManagement.Model
{
    public class Package
    {
        readonly private string _id;
        readonly private Size _size;

        public Package(string id, Size size)
        {
            _id = id;
            _size = size;
        }

        public Size Size => _size;
    }
}
