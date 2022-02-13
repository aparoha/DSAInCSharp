using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.SnakeAndLadder
{
	public abstract class BoardEntity
	{

		private int start;
		private int end;

		public BoardEntity(int start, int end)
		{
			this.start = start;
			this.end = end;
		}

		public abstract string getEncounterMessage();
		public abstract string getString();

		public int getStart()
		{
			return start;
		}
		public void setStart(int start)
		{
			this.start = start;
		}
		public int getEnd()
		{
			return end;
		}
		public void setEnd(int end)
		{
			this.end = end;
		}

	}
}
