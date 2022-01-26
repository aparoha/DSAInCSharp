using System.Collections.Generic;

namespace DSAProblems.LLD.Chess.Composition
{
    public class Piece
    {
        private List<Move> _allowedMoves;
        public Piece(List<Move> allowedMoves)
        {
            this._allowedMoves = allowedMoves;
        }

        public bool CanMove(Cell source, Cell destination)
        {
            foreach(Move allowedMove in _allowedMoves)
            {
                if(allowedMove.CanMove(source, destination))
                    return true;
            }
            return false;
        }
    }
}
