using System;
using System.Collections.Generic;
using System.Linq;

namespace DSAProblems.Techniques
{
    class Backtracking
    {
        public IList<IList<int>> findSubsets(int[] nums) {
            var list = new List<IList<int>>();
            Array.Sort(nums);
            backtrack(list, new List<int>(), nums, 0);
            return list;
        }

        private void backtrack(List<IList<int>> list , List<int> tempList, int [] nums, int start){
            list.Add(new List<int>(tempList));
            for(int i = start; i < nums.Length; i++){
                tempList.Add(nums[i]);
                backtrack(list, tempList, nums, i + 1);
                tempList.Remove(tempList.Count - 1);
            }
        }

        public IList<IList<int>> permute(int[] nums) {
            IList<IList<int>> list = new List<IList<int>>();
            backtrack(list, new List<int>(), nums);
            return list;
        }

        private void backtrack(IList<IList<int>> list, List<int> tempList, int[] nums){
            if(tempList.Count == nums.Length){
                list.Add(new List<int>(tempList));
            } else{
                for(int i = 0; i < nums.Length; i++){ 
                    if(tempList.Contains(nums[i])) continue; // element already exists, skip
                    tempList.Add(nums[i]);
                    backtrack(list, tempList, nums);
                    tempList.RemoveAt(tempList.Count - 1);
                }
            }
        } 
    }
}
