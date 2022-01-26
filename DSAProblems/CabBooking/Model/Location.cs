using System;

namespace CabBooking.Model
{
    public class Location
    {
        public double X { get; }
        public double Y { get; }
        public Location(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double CalculateDistance(Location location)
        {
            return Math.Sqrt(Math.Pow(this.X - location.X, 2) + Math.Pow(this.Y - location.Y, 2));
        }
            
    }
}
