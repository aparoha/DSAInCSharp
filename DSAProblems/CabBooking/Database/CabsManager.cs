using CabBooking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabBooking.Database
{
    public class CabsManager
    {
        private Dictionary<string, Cab> _cabs;

        public CabsManager()
        {
            _cabs = new Dictionary<string, Cab>();
        }

        public void CreateCab(Cab newCab)
        {
            if(_cabs.ContainsKey(newCab.ID))
                throw new Exception("Cab already exists");
            _cabs.Add(newCab.ID, newCab);
        }

        public Cab GetCab(string cabId)
        {
            if(!_cabs.ContainsKey(cabId))
                throw new Exception("Cab not found exception");
            return _cabs[cabId];
        }

        public void UpdateCabLocation(string cabId, Location newLocation)
        {
            if (!_cabs.ContainsKey(cabId))
                throw new Exception("Cab not found exception");
            _cabs[cabId].CurrentLocation = newLocation;
        }
    }
}
