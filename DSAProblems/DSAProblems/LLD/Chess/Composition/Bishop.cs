using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.Chess.Composition
{
    public class Bishop : Piece
    {
        private List<Move> _allowedMoves;
        public Bishop(List<Move> allowedMoves) : base(allowedMoves)
        {
            this._allowedMoves = allowedMoves;
        }
    }
}
