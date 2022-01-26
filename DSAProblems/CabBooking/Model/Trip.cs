using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabBooking.Model
{
    enum TripStatus { IN_PROGRESS, FINISHED };
    public class Trip
    {
        private Rider _rider;
        private Cab _cab;
        private TripStatus _tripStatus;
        private double _price;
        private Location _fromPoint;
        private Location _toPoint;

        public Trip(
            Rider rider,
            Cab cab,
            double price,
            Location fromPoint,
            Location toPoint
            )
        {
            _rider = rider;
            _cab = cab;
            _price = price;
            _fromPoint = fromPoint;
            _toPoint = toPoint;
        }

        public void EndTrip()
        {
            _tripStatus = TripStatus.FINISHED;
        }
    }
}
