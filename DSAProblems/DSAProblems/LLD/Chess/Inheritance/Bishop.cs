using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.Chess.Inheritance
{
    public class Bishop : Piece
    {
        public override bool CanMove(Cell source, Cell destination)
        {
            //Check if source and destination in diagonal
            return true;
        }
    }
}
