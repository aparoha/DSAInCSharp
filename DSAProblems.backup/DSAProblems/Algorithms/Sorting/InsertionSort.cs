using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.Algorithms.Sorting
{
    class InsertionSort
    {
        public void Sort(int[] arr)
        {
            for(int i = 1; i < arr.Length; i++)
            {
                int currentValue = arr[i];
                int position = i;
                while (position > 0 && arr[position - 1] > currentValue)
                {
                    arr[position] = arr[position - 1];
                    position = position - 1;
                }
                arr[position] = currentValue;
            }
        }
    }
}
