using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.Chess.Composition
{
    public interface Move
    {
        bool CanMove(Cell source, Cell destination);
    }
}
