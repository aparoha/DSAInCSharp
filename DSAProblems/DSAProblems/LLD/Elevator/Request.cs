using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.Elevator
{
    public enum Location
    {
        INSIDE_ELEVATOR,
        OUTSIDE_ELEVATOR
    }

    public enum Direction
    {
        UP,
        DOWN,
        IDLE
    }
    public class Request : IEquatable<Request>
    {
        private readonly int _currentFloor;
        private readonly int _desiredFloor;
        private readonly Direction _direction;
        private readonly Location _location;

        public Request(int currentFloor, int desiredFloor, Direction direction, Location location)
        {
            _currentFloor = currentFloor;
            _desiredFloor = desiredFloor;
            _direction = direction;
            _location = location;
        }

        public int CurrentFloor => _currentFloor;

        public int DesiredFloor => _desiredFloor;

        public Direction Direction => _direction;

        public Location Location => _location;

        public override bool Equals(object obj)
        {
            return Equals(obj as Request);
        }

        public bool Equals(Request other)
        {
            return other != null &&
                   _currentFloor == other._currentFloor &&
                   _desiredFloor == other._desiredFloor &&
                   _direction == other._direction &&
                   _location == other._location;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_currentFloor, _desiredFloor, _direction, _location);
        }

        public static bool operator ==(Request left, Request right)
        {
            return EqualityComparer<Request>.Default.Equals(left, right);
        }

        public static bool operator !=(Request left, Request right)
        {
            return !(left == right);
        }
    }
}
