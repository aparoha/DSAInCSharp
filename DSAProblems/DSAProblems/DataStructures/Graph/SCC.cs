using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.DataStructures.Graph
{
    //Strongly Connected Components(SCC) can be thought of as self-contained cycles within
    //a directed graph where every vertex in a given cycle can reach every other vertex in
    //thes ame cycle. SCCs in a graph are unique

    //Depending on where the DFS starts, and the order in which nodes/edges are visited, the low-link
    //values for identifying SCCs could be wrong. In the context of Tarjan's SCC algorithm, we maintain
    //an invariant that prevents SCCs to interfere with the low link value of other SCCs

    //Tarjan's Algorithm
    //Concept
    //Low-link values = The low-link value of a node is the smallest [lowest] node id reachable 
    //from that node when doing a DFS (including itself)

    //The Stack Invariant
    //1. To cope with the random traversal order of DFS, Tarjan's algorithm maintains a set (or stack) of
    //   valid nodes from which to update low-link values from
    //2. Nodes are added to the set (stack) of valid nodes as they're explored for the first time
    //3. Nodes are removed from the set (stack) each time a complete SCC is found

    //New low-link update condition
    //If u and v are nodes in a graph and we are currently exploring u then our new low-link update condition
    //To update node u's low-link value to node v's low-link value there has to be a path of edges from u to v
    //AND node v must be on the stack

    //TC - O(V+E)

    //Steps
    //1. Mark the id of each node as unvisited
    //2. Start DFS. Upon visiting a node assign it an id and a low-link value. Also mark current node as visited
    //   and add them to a seen stack
    //3. On DFS callback, if the previous node is on the stack then min the current node's low-link value with the
    //   last node's low-link value. This allows low-link values to propagate throughout cycle
    //4. After visiting all neighbors, if the current node started a connected component then pop nodes off stack
    //   until the current node is reached. A node started a connected component if its id equals its low-link value
    public class SCC
    {

    }
}
