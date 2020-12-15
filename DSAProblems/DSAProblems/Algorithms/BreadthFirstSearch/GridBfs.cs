using System.Collections.Generic;
using System.Linq;

namespace DSAProblems.Algorithms.BreadthFirstSearch
{
    //https://medium.com/@manpreetsingh.16.11.87/shortest-path-in-a-2d-array-java-653921063884
    //    Problem:
    //    Given a 2D array with values as ‘S’, ‘D’, ‘1’ and ‘0’.
    //    - S is the Source
    //    - D is the Destination
    //    - 1 marks the valid path
    //    - 0 marks the obstacle
    //    Find the shortest distance from S to D avoiding all the obstacles.

    //Approach:
    //1.Starting from the source ‘S’, add it to the queue
    //2.Remove the first node from the queue and mark it visited so that it should not be processed again.
    //3.For the node just removed from the queue in step 2, check all the neighboring nodes
    //4.If the x & y value of the node is within the values of given matrix and the node has not been marked visited yet, add it to the queue along with the distance of this node from the source ‘S’
    //5.Repeat steps 2 to 4 until you reach to the node which is equal to ‘D’ (Destination)
    //6.If there is a path available from S to D, the distance will be displayed, other wise it will print ‘-1’

    //    new []
    //    {
    //        new []{'S', '0', '1', '1'},
    //        new []{'1', '1', '0', '1'},
    //        new []{'0', '1', '1', '1'},
    //        new []{'1', '0', 'D', '1'}
    //    }
    class GridBfs
    {
        public int PathExists(char[][] grid)
        {
            Node source = new Node(0, 0, 0);
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(source);

            while (queue.Any())
            {
                Node current = queue.Dequeue();
                if (grid[current.X][current.Y] == 'D')
                {
                    return current.DistanceFormSource;
                }
                grid[current.X][current.Y] = '0';
                List<Node> neighbors = GetNeighbors(current, grid);
                foreach (var neighbor in neighbors)
                {
                    queue.Enqueue(neighbor);
                }
            }    
            return -1;
        }

        public List<Node> GetNeighbors(Node current, char[][] grid)
        {
            List<Node> result = new List<Node>();
            if ((current.X > 0 && current.X - 1 < grid.Length) && (grid[current.X - 1][current.Y] != '0'))
            {
                result.Add(new Node(current.X - 1, current.Y, current.DistanceFormSource + 1));
            }
            if ((current.X + 1 > 0 && current.X + 1 < grid.Length) && (grid[current.X + 1][current.Y] != '0'))
            {
                result.Add(new Node(current.X + 1, current.Y, current.DistanceFormSource + 1));
            }
            if ((current.Y - 1 > 0 && current.Y - 1 < grid.Length) && (grid[current.X][current.Y - 1] != '0'))
            {
                result.Add(new Node(current.X, current.Y - 1, current.DistanceFormSource + 1));
            }
            if ((current.Y + 1 > 0 && current.Y + 1 < grid.Length) && (grid[current.X][current.Y + 1] != '0'))
            {
                result.Add(new Node(current.X, current.Y + 1, current.DistanceFormSource + 1));
            }
            return result;
        }

        public class Node
        {
            public int X;
            public int Y;
            public int DistanceFormSource;

            public Node(int x, int y, int distanceFormSource)
            {
                X = x;
                Y = y;
                DistanceFormSource = distanceFormSource;
            }
        }
    }
}
