using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.Chess.Inheritance
{
    public class Queen : Piece
    {
        public override bool CanMove(Cell source, Cell destination)
        {
            //Check if source and destination in diagonal
            //Check if source and destination is in horizontal
            //Check if source and destination is vertical
            return true;
        }
    }
}
