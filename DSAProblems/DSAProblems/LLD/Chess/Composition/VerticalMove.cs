using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.Chess.Composition
{
    public class VerticalMove : Move
    {
        public bool CanMove(Cell source, Cell destination)
        {
            return false;
        }
    }
}
