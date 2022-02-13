using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.SnakeAndLadder
{
    public class DiceService
    {
        public int roll(int n)
        {
            Random random = new Random();
            int min = 1;
            int max = n * 6;
            return random.Next() * (max - min + 1) + min;
        }
    }
}
