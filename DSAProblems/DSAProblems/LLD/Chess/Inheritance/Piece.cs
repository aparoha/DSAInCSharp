using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.Chess.Inheritance
{
    public class Piece
    {
        public virtual bool CanMove(Cell source, Cell destination)
        {
            return false;
        }
    }
}
