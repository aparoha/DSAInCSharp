using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.ParkingLot.Model
{
    public class Car
    {
        public string RegistrationNumber { get; private set; }
        public string Color { get; private set; }
        public Car(string registrationNumber, string color)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
        }
    }
}
