using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.LockerManagement.Model
{
    public class Size
    {
        readonly private double _width;
        readonly private double _height;

        public Size(double width, double height)
        {
            _width = width;
            _height = height;
        }

        public bool CanAccomadate(Size sizeToAccommodate)
        {
            return _width >= sizeToAccommodate._width && _height >= sizeToAccommodate._height;
        }
    }
}
