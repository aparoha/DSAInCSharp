using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.Elevator
{
    /* Assumptions
     * 1. In real life, the elevator will finish all up requests before starting down requests.
     * 2. Let’s assume that going up has more priority than going down
     * 3. when the elevator is in IDLE state, and has both up and down requests, it will execute up requests first.
     * 4. max heap to store all down requests and sort them by their desired floor
     * 5. a min heap to store all up requests and sort them by their desired floor
     * 6. When, the requester is outside of the elevator, the elevator needs to stop at the currentFloor of the requester, before going to the desiredFloor of the requester
     * 
     * https://tedweishiwang.github.io/journal/object-oriented-design-elevator.html
     * 
     */
    public class Elevator
    {
        private int _currentFloor;
        private Direction _direction;
        private PriorityQueue<Request, int> _upQueue;
        private PriorityQueue<Request, int> _downQueue;

        public Elevator(int currentFloor)
        {
            _currentFloor = currentFloor;
            _direction = Direction.IDLE;
            _upQueue = new PriorityQueue<Request, int>();
            _downQueue = new PriorityQueue<Request, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        }

        public void SendUpRequet(Request upRequest)
        {
            if(upRequest.Location == Location.OUTSIDE_ELEVATOR)
            {
                Request request = new Request(
                    upRequest.CurrentFloor,
                    upRequest.CurrentFloor,
                    Direction.UP,
                    Location.OUTSIDE_ELEVATOR
                    );
                _upQueue.Enqueue(request, request.DesiredFloor);
            }
            _upQueue.Enqueue(upRequest, upRequest.DesiredFloor);
        }
    }
}
