using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabBooking.Model
{
    public class Cab
    {
        public Trip CurrentTrip;
        public Location CurrentLocation {  get; set;}
        public bool IsAvailable { get; set; }
        public string ID {  get; private set; }
        public string DriverName { get; private set; }
        public Cab(string id, string driverName)
        {
            ID = id;
            DriverName = driverName;
            IsAvailable = true;
        }
    }
}
